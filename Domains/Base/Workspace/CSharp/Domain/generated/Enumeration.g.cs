// Allors generated file. 
// Do not edit this file, changes will be overwritten.
namespace Allors.Workspace.Domain
{
	public partial interface Enumeration : ISessionObject  , UniquelyIdentifiable 
	{


		LocalisedText[] LocalisedNames
		{ 
			get;
			set;
		}

		void AddLocalisedName (LocalisedText value);

		void RemoveLocalisedName (LocalisedText value);

		bool ExistLocalisedNames
		{
			get;
		}

		void RemoveLocalisedNames();


		global::System.String Name 
		{
			get;
			set;
		}

		bool ExistName{get;}

		void RemoveName();



		global::System.Boolean IsActive 
		{
			get;
			set;
		}

		bool ExistIsActive{get;}

		void RemoveIsActive();


	}
}