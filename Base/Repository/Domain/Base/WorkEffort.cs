// <copyright file="WorkEffort.cs" company="Allors bvba">
// Copyright (c) Allors bvba. All rights reserved.
// Licensed under the LGPL license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Allors.Repository
{
    using System;

    using Allors.Repository.Attributes;

    #region Allors
    [Id("553a5280-a768-4ba1-8b5d-304d7c4bb7f1")]
    #endregion
    public partial interface WorkEffort : Transitional, UniquelyIdentifiable, Deletable, Auditable, Commentable, Printable
    {
        #region WorkEffortState
        #region Allors
        [Id("4240C679-19EA-41B9-A82D-D156DE6B4007")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        WorkEffortState PreviousWorkEffortState { get; set; }

        #region Allors
        [Id("0144D0DC-B981-4FD2-B6D1-1629F6957A5D")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Derived]
        WorkEffortState LastWorkEffortState { get; set; }

        #region Allors
        [Id("22325B2E-AD74-4B12-9F5B-856858B002DD")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        WorkEffortState WorkEffortState { get; set; }
        #endregion

        #region Allors
        [Id("15F7EFA9-5A93-4921-8C42-D9CEC1F0EA63")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        Organisation TakenBy { get; set; }

        #region Allors
        [Id("3B6366EB-AD53-4F35-AE0F-EFD9503CF271")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        Organisation ExecutedBy { get; set; }

        #region Allors
        [Id("0db9b217-c54f-4a7b-a1c0-9592eeabd51f")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Workspace]
        Facility Facility { get; set; }

        #region Allors
        [Id("5012F30D-1B22-47D7-B3A5-42F023FEE3E1")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Required]
        [Workspace]
        Party Customer { get; set; }

        #region Allors
        [Id("2C866A1C-AC26-468A-B01F-5A0D8FFF7513")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        ContactMechanism FullfillContactMechanism { get; set; }

        #region Allors
        [Id("DE8ABB5B-E0CB-4FDA-AF49-D6359E909E31")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Workspace]
        Person ContactPerson { get; set; }

        #region Allors
        [Id("E938CD9B-C1E3-4DA6-BB0A-1DF917061A56")]
        #endregion
        [Workspace]
        [Derived]
        [Required]
        [Size(256)]
        string WorkEffortNumber { get; set; }

        #region Allors
        [Id("3C1D7BA5-A031-4890-85C8-0119EF754F5D")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        Person Owner { get; set; }

        #region Allors
        [Id("97a874e9-10ef-43fb-80d2-10e0974bb3a1")]
        #endregion
        [Size(256)]
        [Required]
        [Workspace]
        string Name { get; set; }

        #region Allors
        [Id("bac1939b-8cf8-4b18-862c-4c2dc0a591e5")]
        #endregion
        [Size(-1)]
        [Workspace]
        string Description { get; set; }

        #region Allors
        [Id("B8348A76-34BF-4B1B-B840-0946C52A639D")]
        #endregion
        [Size(-1)]
        [Workspace]
        string WorkDone { get; set; }

        #region Allors
        [Id("858e42df-d775-4eec-b029-343e8b094311")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Workspace]
        Priority Priority { get; set; }

        #region Allors
        [Id("6af30dd9-7f3b-47e7-a929-7ecd28b9b53f")]
        [Indexed]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Workspace]
        WorkEffortPurpose[] WorkEffortPurposes { get; set; }

        #region Allors
        [Id("1cac44f2-bf48-4b7b-9d29-658e6eedeb86")]
        #endregion
        [Indexed]
        [Derived]
        [Workspace]
        DateTime ActualStart { get; set; }

        #region Allors
        [Id("30645381-bb0c-4782-a9cc-388c7406456d")]
        #endregion
        [Indexed]
        [Derived]
        [Workspace]
        DateTime ActualCompletion { get; set; }

        #region Allors
        [Id("aedad096-b297-47b7-98e4-69c6dde9b128")]
        #endregion
        [Indexed]
        [Required]
        [Workspace]
        DateTime ScheduledStart { get; set; }

        #region Allors
        [Id("e189f9fc-fe3c-44af-985a-cdc3e749e25c")]
        #endregion
        [Indexed]
        [Workspace]
        DateTime ScheduledCompletion { get; set; }

        #region Allors
        [Id("b6213705-ed58-4597-9939-a058b89610f8")]
        #endregion
        [Derived]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal ActualHours { get; set; }

        #region Allors
        [Id("ebd0daa8-ab45-4390-89f7-3bc89faecdfb")]
        #endregion
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal EstimatedHours { get; set; }

        #region Allors
        [Id("f5580447-3ac9-4bef-82db-f3e98652fae7")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal TotalLabourCost { get; set; }

        #region Allors
        [Id("55ed26a9-c025-4232-87d5-99d8f5cfd108")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal TotalMaterialCost{ get; set; }

        #region Allors
        [Id("5fdb39db-0777-447b-9eb2-239a5aec0383")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal TotalSubContractedCost { get; set; }

        #region Allors
        [Id("1cf26872-3f96-430c-a4b8-cfde33cf628c")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal TotalCost { get; set; }

        #region Allors
        [Id("1c16f9d0-9d2e-47cc-b097-e63d4de43ea6")]
        #endregion
        [Derived]
        [Required]
        [Precision(19)]
        [Scale(2)]
        [Workspace]
        decimal TotalRevenue { get; set; }

        #region Allors
        [Id("092a296d-6f15-4fdd-aed6-25185e6e10b1")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        [Workspace]
        WorkEffort[] Precendencies { get; set; }

        #region Allors
        [Id("1a3705c0-0e77-4d6d-a368-ef5141a6c908")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        [Workspace]
        Deliverable[] DeliverablesProduced { get; set; }

        #region Allors
        [Id("2efd427f-daeb-4b84-9f86-857ed1bdb1b7")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        [Workspace]
        WorkEffort[] Children { get; set; }

        #region Allors
        [Id("3081fa56-272c-43d6-a54c-ad70cb233034")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        OrderItem OrderItemFulfillment { get; set; }

        #region Allors
        [Id("3bebd379-65a9-445e-898e-8913c26b94e6")]
        #endregion
        [Multiplicity(Multiplicity.ManyToOne)]
        [Indexed]
        [Workspace]
        WorkEffortType WorkEffortType { get; set; }

        #region Allors
        [Id("a60c8797-320d-471f-9755-d3ef20a4feac")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        [Workspace]
        Requirement[] RequirementFulfillments { get; set; }

        #region Allors
        [Id("a6fa6291-501a-4b5e-992d-ee5b9a291700")]
        #endregion
        [Size(-1)]
        [Workspace]
        string SpecialTerms { get; set; }

        #region Allors
        [Id("add2f3d5-d83a-4734-ad69-9f86eb116f06")]
        #endregion
        [Multiplicity(Multiplicity.ManyToMany)]
        [Indexed]
        [Workspace]
        WorkEffort[] Concurrencies { get; set; }

        #region Allors
        [Id("76EEC72E-3636-42FD-9F50-B1A2818A2CC3")]
        #endregion
        [Derived]
        [Required]
        [Workspace]
        bool CanInvoice { get; set; }

        #region Allors
        [Id("f013bc49-c622-48ed-a6d0-1cf677405498")]
        #endregion
        [Multiplicity(Multiplicity.OneToMany)]
        [Indexed]
        [Workspace]
        public Media[] ElectronicDocuments { get; set; }

        #region Allors
        [Id("d21f9909-1dfd-4c7d-9559-68fb1fc29f26")]
        #endregion
        [Indexed]
        [Derived]
        [Workspace]
        int SortableWorkEffortNumber { get; set; }

        #region Allors
        [Id("163a5552-9436-4ecf-9b44-9f3cc6ab488f")]
        #endregion
        [Required]
        [Workspace]
        Guid DerivationTrigger { get; set; }

        #region Allors
        [Id("D9234724-215F-4F6C-B3E8-9743CB22A245")]
        #endregion
        [Workspace]
        void Cancel();

        #region Allors
        [Id("F581B87C-EE9D-4D43-9719-8BC5CCFAC2C3")]
        #endregion
        [Workspace]
        void Reopen();

        #region Allors
        [Id("A0DA49D5-9AB3-4F1C-A40C-81644ADDD411")]
        #endregion
        [Workspace]
        void Complete();

        #region Allors
        [Id("506B288D-94C1-4157-A244-B62887BEA609")]
        #endregion
        [Workspace]
        void Invoice();

        #region Allors
        [Id("ea3b83de-aeac-406d-aaf3-0fcfd57bcaef")]
        #endregion
        [Workspace]
        void Revise();

        #region Allors
        [Id("6040f364-eec8-4672-add6-4d2590028d50")]
        #endregion
        [Workspace]
        void CalculateTotalRevenue();
    }
}
