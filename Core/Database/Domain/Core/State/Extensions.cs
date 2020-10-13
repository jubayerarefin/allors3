// <auto-generated />
// Do not edit this file, changes will be overwritten.
namespace Allors
{
    public static partial class ObjectsExtensions
    {
        public static ISessionState SessionState(this IObjects @this) => @this.Session.State();

        public static IDatabaseState DatabaseState(this IObjects @this) => @this.Session.Database.State();
    }
    
    public static partial class ObjectExtensions
    {
        public static ISessionState SessionState(this IObject @this) => @this.Strategy.Session.State();

        public static IDatabaseState DatabaseState(this IObject @this) => @this.Strategy.Session.Database.State();
    }

    public static partial class SessionExtensions
    {
        public static ISessionState State(this ISession @this) => ((ISessionState)@this.StateLifecycle);
    }

    public static partial class DatabaseExtensions
    {
        public static IDatabaseState State(this IDatabase @this) => ((IDatabaseState)@this.StateLifecycle);
    }
}