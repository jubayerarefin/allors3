// Allors generated file.
// Do not edit this file, changes will be overwritten.
namespace libs.workspace.angular.apps.src.lib.objects.facetofacecommunication.edit
{
    using OpenQA.Selenium;
    using Components;

    public partial class FaceToFaceCommunicationEditComponent : Components.EntryComponent
    {
        public FaceToFaceCommunicationEditComponent(IWebDriver driver, Allors.Database.Meta.MetaPopulation m) : base(driver, m)
        {
        }

        public Components.MatSelect<FaceToFaceCommunicationEditComponent> CommunicationEventState => this.MatSelect(this.M.CommunicationEvent.CommunicationEventState, "FaceToFaceCommunicationEditComponent");


        public Components.MatSelect<FaceToFaceCommunicationEditComponent> EventPurposes => this.MatSelect(this.M.CommunicationEvent.EventPurposes, "FaceToFaceCommunicationEditComponent");


        public Components.MatInput<FaceToFaceCommunicationEditComponent> Subject => this.MatInput(this.M.CommunicationEvent.Subject, "FaceToFaceCommunicationEditComponent");


        public Components.MatSelect<FaceToFaceCommunicationEditComponent> FromParty => this.MatSelect(this.M.CommunicationEvent.FromParty, "FaceToFaceCommunicationEditComponent");


        public Components.Button Addclose_1 => new Components.Button(this.Driver, this.M, "InnerText", @"add
              close", "FaceToFaceCommunicationEditComponent");







        public Components.MatSelect<FaceToFaceCommunicationEditComponent> ToParty => this.MatSelect(this.M.CommunicationEvent.ToParty, "FaceToFaceCommunicationEditComponent");


        public Components.Button Addclose_2 => new Components.Button(this.Driver, this.M, "InnerText", @"add
              close", "FaceToFaceCommunicationEditComponent");







        public Components.MatDatetimepicker<FaceToFaceCommunicationEditComponent> ScheduledStart => this.MatDatetimepicker(this.M.CommunicationEvent.ScheduledStart, "FaceToFaceCommunicationEditComponent");


        public Components.MatDatetimepicker<FaceToFaceCommunicationEditComponent> ScheduledEnd => this.MatDatetimepicker(this.M.CommunicationEvent.ScheduledEnd, "FaceToFaceCommunicationEditComponent");


        public Components.MatDatetimepicker<FaceToFaceCommunicationEditComponent> ActualStart => this.MatDatetimepicker(this.M.CommunicationEvent.ActualStart, "FaceToFaceCommunicationEditComponent");


        public Components.MatDatetimepicker<FaceToFaceCommunicationEditComponent> ActualEnd => this.MatDatetimepicker(this.M.CommunicationEvent.ActualEnd, "FaceToFaceCommunicationEditComponent");


        public Components.MatInput<FaceToFaceCommunicationEditComponent> Location => this.MatInput(this.M.FaceToFaceCommunication.Location, "FaceToFaceCommunicationEditComponent");


        public Components.MatTextarea<FaceToFaceCommunicationEditComponent> Comment => this.MatTextarea(this.M.Commentable.Comment, "FaceToFaceCommunicationEditComponent");


        public Components.Button CANCEL => new Components.Button(this.Driver, this.M, "InnerText", @"CANCEL", "FaceToFaceCommunicationEditComponent");


        public Components.Button SAVE => new Components.Button(this.Driver, this.M, "InnerText", @"SAVE", "FaceToFaceCommunicationEditComponent");

    }
}