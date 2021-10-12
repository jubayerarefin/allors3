// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.workeffortpartyassignment.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class WorkEffortPartyAssignmentEditComponent : Components.EntryComponent
    {
        public WorkEffortPartyAssignmentEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatDatetimepicker<WorkEffortPartyAssignmentEditComponent> FromDate => this.MatDatetimepicker(this.M.WorkEffortPartyAssignment.FromDate, "WorkEffortPartyAssignmentEditComponent");


        public Components.MatDatetimepicker<WorkEffortPartyAssignmentEditComponent> ThroughDate => this.MatDatetimepicker(this.M.WorkEffortPartyAssignment.ThroughDate, "WorkEffortPartyAssignmentEditComponent");


        public Components.MatStatic<WorkEffortPartyAssignmentEditComponent> PartyStatic => this.MatStatic(this.M.WorkEffortPartyAssignment.Party, "WorkEffortPartyAssignmentEditComponent");


        public Components.MatSelect<WorkEffortPartyAssignmentEditComponent> Party => this.MatSelect(this.M.WorkEffortPartyAssignment.Party, "WorkEffortPartyAssignmentEditComponent");


        public Components.MatTextarea<WorkEffortPartyAssignmentEditComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "WorkEffortPartyAssignmentEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "WorkEffortPartyAssignmentEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "WorkEffortPartyAssignmentEditComponent");

    }
}