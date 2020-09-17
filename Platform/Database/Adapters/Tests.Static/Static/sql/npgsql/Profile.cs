// <copyright file="Profile.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Database.Adapters.Npgsql
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Caching;
    using Domain;
    using global::Npgsql;
    using Meta;
    using Microsoft.Extensions.DependencyInjection;
    using ObjectFactory = Allors.ObjectFactory;

    public class Profile : Adapters.Profile
    {
        private readonly string database;
        private readonly IConnectionFactory connectionFactory;
        private readonly ICacheFactory cacheFactory;

        public Profile(string database, IConnectionFactory connectionFactory = null, ICacheFactory cacheFactory = null)
        {
            this.database = database.ToLowerInvariant();
            this.connectionFactory = connectionFactory;
            this.cacheFactory = cacheFactory;
        }

        public override Action[] Markers
        {
            get
            {
                var markers = new List<Action>
                {
                    () => { },
                    () => this.Session.Commit(),
                };

                return markers.ToArray();
            }
        }

        protected string ConnectionString => $"Server=localhost; User Id=postgres; Password=test; Database={this.database}; Pooling=false; CommandTimeout=300";

        public override IDatabase CreateDatabase()
        {
            var metaPopulation = new MetaBuilder().Build();
            var m = new M(metaPopulation);
            return new Database(new ServiceCollection().BuildServiceProvider(), new Configuration
            {
                Meta = m,
                ObjectFactory = new ObjectFactory(metaPopulation, typeof(C1)),
                ConnectionString = this.ConnectionString,
                ConnectionFactory = this.connectionFactory,
                CacheFactory = this.cacheFactory,
            });
        }
        
        public void DropTable(string tableName)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql = new StringBuilder();
                    sql.Append("DROP TABLE IF EXISTS " + tableName);
                    command.CommandText = sql.ToString();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool ExistIndex(string table, string column)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql = new StringBuilder();
                    sql.Append("SELECT COUNT(*)\n");
                    sql.Append("FROM pg_class, pg_attribute, pg_index\n");
                    sql.Append("WHERE pg_class.oid = pg_attribute.attrelid AND\n");
                    sql.Append("pg_class.oid = pg_index.indrelid AND\n");
                    sql.Append("pg_index.indkey[0] = pg_attribute.attnum\n");

                    sql.Append("AND lower(pg_class.relname) = '" + table.ToLower() + "'\n");
                    sql.Append("AND lower(pg_attribute.attname) = '" + column.ToLower() + "'\n");

                    command.CommandText = sql.ToString();
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        public bool ExistProcedure(string procedure)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql =
@"SELECT ROUTINE_NAME, ROUTINE_DEFINITION 
FROM INFORMATION_SCHEMA.ROUTINES
WHERE lower(ROUTINE_NAME) = '" + procedure.ToLower() + @"'";

                    command.CommandText = sql;
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        public bool ExistPrimaryKey(string table, string column)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql =
@"select count(*) 
from information_schema.constraint_column_usage 
where lower(table_name) = '" + table.ToLowerInvariant() + "' and lower(constraint_name) = '" + table.ToLowerInvariant() + "_pk'";

                    command.CommandText = sql;
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        public bool IsInteger(string table, string column)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql =
@"SELECT count(*)
FROM information_schema.columns
WHERE lower(table_name) = '" + table.ToLower() + @"'
AND lower(column_name) = '" + column.ToLower() + @"'
AND data_type = 'integer'";

                    command.CommandText = sql;
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        public bool IsLong(string table, string column)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql =
@"SELECT count(*)
FROM information_schema.columns
WHERE lower(table_name) = '" + table.ToLower() + @"'
AND lower(column_name) = '" + column.ToLower() + @"'
AND data_type = 'bigint'";

                    command.CommandText = sql;
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        public bool IsUnique(string table, string column)
        {
            using (var connection = this.CreateConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var sql =
@"SELECT count(*)
FROM information_schema.columns
WHERE lower(table_name) = '" + table.ToLower() + @"'
AND lower(column_name) = '" + column.ToLower() + @"'
AND data_type = 'uuid'";

                    command.CommandText = sql;
                    var count = (long)command.ExecuteScalar();

                    return count != 0;
                }
            }
        }

        private NpgsqlConnection CreateConnection() => new NpgsqlConnection(this.ConnectionString);
    }
}
