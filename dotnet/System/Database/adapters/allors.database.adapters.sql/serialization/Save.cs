// <copyright file="Save.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Adapters.Sql
{
    using System.Collections.Generic;
    using System.Xml;
    using Adapters;
    using Meta;

    public class Save
    {
        private readonly Database database;
        private readonly XmlWriter writer;

        public Save(Database database, XmlWriter writer)
        {
            this.database = database;
            this.writer = writer;
        }

        public virtual void Execute(ManagementTransaction transaction)
        {
            var writeDocument = false;
            if (this.writer.WriteState == WriteState.Start)
            {
                this.writer.WriteStartDocument();
                this.writer.WriteStartElement(Serialization.Allors);
                writeDocument = true;
            }

            this.writer.WriteStartElement(Serialization.Population);
            this.writer.WriteAttributeString(Serialization.Version, Serialization.VersionCurrent.ToString());

            this.writer.WriteStartElement(Serialization.Objects);
            this.writer.WriteStartElement(Serialization.Database);
            this.SaveObjects(transaction);
            this.writer.WriteEndElement();
            this.writer.WriteEndElement();

            this.writer.WriteStartElement(Serialization.Relations);
            this.writer.WriteStartElement(Serialization.Database);
            this.SaveRelations(transaction);
            this.writer.WriteEndElement();
            this.writer.WriteEndElement();

            this.writer.WriteEndElement();

            if (writeDocument)
            {
                this.writer.WriteEndElement();
                this.writer.WriteEndDocument();
            }
        }

        protected void SaveObjects(ManagementTransaction transaction)
        {
            var mapping = this.database.Mapping;

            var concreteCompositeType = new List<IClass>(this.database.MetaPopulation.DatabaseClasses);
            concreteCompositeType.Sort();
            foreach (var type in concreteCompositeType)
            {
                var atLeastOne = false;

                var sql = "SELECT " + Mapping.ColumnNameForObject + ", " + Mapping.ColumnNameForVersion + "\n";
                sql += "FROM " + this.database.Mapping.TableNameForObjects + "\n";
                sql += "WHERE " + Mapping.ColumnNameForClass + "=" + mapping.ParamInvocationNameForClass + "\n";
                sql += "ORDER BY " + Mapping.ColumnNameForObject;

                using (var command = transaction.Connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.AddInParameter(mapping.ParamNameForClass, type.Id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!atLeastOne)
                            {
                                atLeastOne = true;

                                this.writer.WriteStartElement(Serialization.ObjectType);
                                this.writer.WriteAttributeString(Serialization.Id, type.Id.ToString());
                            }
                            else
                            {
                                this.writer.WriteString(Serialization.ObjectsSplitter);
                            }

                            var objectId = long.Parse(reader[0].ToString());
                            var version = reader[1].ToString();

                            this.writer.WriteString(objectId + Serialization.ObjectSplitter + version);
                        }
                    }
                }

                if (atLeastOne)
                {
                    this.writer.WriteEndElement();
                }
            }
        }

        protected void SaveRelations(ManagementTransaction transaction)
        {
            var exclusiveRootClassesByObjectType = new Dictionary<IObjectType, HashSet<IObjectType>>();

            var relations = new List<IRelationType>(this.database.MetaPopulation.DatabaseRelationTypes);
            relations.Sort();

            foreach (var relation in relations)
            {
                var associationType = relation.AssociationType;

                if (associationType.ObjectType.ExistDatabaseClass)
                {
                    var roleType = relation.RoleType;

                    var sql = string.Empty;
                    if (roleType.ObjectType.IsUnit)
                    {
                        if (!exclusiveRootClassesByObjectType.TryGetValue(associationType.ObjectType, out var exclusiveRootClasses))
                        {
                            exclusiveRootClasses = new HashSet<IObjectType>();
                            foreach (var concreteClass in associationType.ObjectType.DatabaseClasses)
                            {
                                exclusiveRootClasses.Add(concreteClass.ExclusiveDatabaseClass);
                            }

                            exclusiveRootClassesByObjectType[associationType.ObjectType] = exclusiveRootClasses;
                        }

                        var first = true;
                        foreach (var exclusiveRootClass in exclusiveRootClasses)
                        {
                            if (first)
                            {
                                first = false;
                            }
                            else
                            {
                                sql += "UNION\n";
                            }

                            sql += "SELECT " + Mapping.ColumnNameForObject + " As " + Mapping.ColumnNameForAssociation + ", " + this.database.Mapping.ColumnNameByRelationType[roleType.RelationType] + " As " + Mapping.ColumnNameForRole + "\n";
                            sql += "FROM " + this.database.Mapping.TableNameForObjectByClass[(IClass)exclusiveRootClass] + "\n";
                            sql += "WHERE " + this.database.Mapping.ColumnNameByRelationType[roleType.RelationType] + " IS NOT NULL\n";
                        }

                        sql += "ORDER BY " + Mapping.ColumnNameForAssociation;
                    }
                    else if ((roleType.IsMany && associationType.IsMany) || !relation.ExistExclusiveDatabaseClasses)
                    {
                        sql += "SELECT " + Mapping.ColumnNameForAssociation + "," + Mapping.ColumnNameForRole + "\n";
                        sql += "FROM " + this.database.Mapping.TableNameForRelationByRelationType[relation] + "\n";
                        sql += "ORDER BY " + Mapping.ColumnNameForAssociation + "," + Mapping.ColumnNameForRole;
                    }
                    else
                    {
                        // use foreign keys
                        if (roleType.IsOne)
                        {
                            sql += "SELECT " + Mapping.ColumnNameForObject + " As " + Mapping.ColumnNameForAssociation + ", " + this.database.Mapping.ColumnNameByRelationType[roleType.RelationType] + " As " + Mapping.ColumnNameForRole + "\n";
                            sql += "FROM " + this.database.Mapping.TableNameForObjectByClass[associationType.ObjectType.ExclusiveDatabaseClass] + "\n";
                            sql += "WHERE " + this.database.Mapping.ColumnNameByRelationType[roleType.RelationType] + " IS NOT NULL\n";
                            sql += "ORDER BY " + Mapping.ColumnNameForAssociation;
                        }
                        else
                        {
                            // role.Many
                            sql += "SELECT " + this.database.Mapping.ColumnNameByRelationType[associationType.RelationType] + " As " + Mapping.ColumnNameForAssociation + ", " + Mapping.ColumnNameForObject + " As " + Mapping.ColumnNameForRole + "\n";
                            sql += "FROM " + this.database.Mapping.TableNameForObjectByClass[((IComposite)roleType.ObjectType).ExclusiveDatabaseClass] + "\n";
                            sql += "WHERE " + this.database.Mapping.ColumnNameByRelationType[associationType.RelationType] + " IS NOT NULL\n";
                            sql += "ORDER BY " + Mapping.ColumnNameForAssociation + "," + Mapping.ColumnNameForRole;
                        }
                    }

                    using (var command = transaction.Connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        using (var reader = command.ExecuteReader())
                        {
                            if (roleType.IsMany)
                            {
                                using (var relationTypeManyXmlWriter = new RelationTypeManyXmlWriter(relation, this.writer))
                                {
                                    while (reader.Read())
                                    {
                                        var a = long.Parse(reader[0].ToString());
                                        var r = long.Parse(reader[1].ToString());
                                        relationTypeManyXmlWriter.Write(a, r);
                                    }
                                }
                            }
                            else
                            {
                                using (var relationTypeOneXmlWriter = new RelationTypeOneXmlWriter(relation, this.writer))
                                {
                                    while (reader.Read())
                                    {
                                        var a = long.Parse(reader[0].ToString());

                                        if (roleType.ObjectType.IsUnit)
                                        {
                                            var unitTypeTag = ((IUnit)roleType.ObjectType).Tag;
                                            var r = command.GetValue(reader, unitTypeTag, 1);
                                            var content = Serialization.WriteString(unitTypeTag, r);
                                            relationTypeOneXmlWriter.Write(a, content);
                                        }
                                        else
                                        {
                                            var r = reader[1];
                                            relationTypeOneXmlWriter.Write(a, XmlConvert.ToString(long.Parse(r.ToString())));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
