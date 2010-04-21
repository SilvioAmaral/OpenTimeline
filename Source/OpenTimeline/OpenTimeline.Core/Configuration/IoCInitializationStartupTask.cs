using OpenTimeline.Core.InversionOfControl;

namespace OpenTimeline.Core.Configuration
{
    public class IoCInitializationStartupTask : IStartupTask
    {
        #region Implementation of IStartupTask

        public void Execute()
        {
            IoC.Initialize(new StructureMapDependecyResolver());
        }

        #endregion
    }
}