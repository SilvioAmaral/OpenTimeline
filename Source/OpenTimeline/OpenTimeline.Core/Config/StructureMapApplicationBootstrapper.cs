using System.Collections.Generic;
using OpenTimeline.Core.Lib;
using StructureMap;

namespace OpenTimeline.Core.Config
{
    public class StructureMapApplicationBootstrapper
    {
        private readonly Container _container = new Container();

        public void Configure()
        {
            RegisterContainerStartupTasks();
            ExecuteContainerStartupTasks();
            RegisterStartupTasks();
            ExecuteStartupTasks();
        }

        private void RegisterContainerStartupTasks()
        {
            RegisterAllTypesBasedOn<IContainerRegistrationTask>();
        }

        private void ExecuteContainerStartupTasks()
        {
            var containerRegistrationTasks = _container.GetAllInstances<IContainerRegistrationTask>();
            containerRegistrationTasks.ForEach(x => x.Register());
        }

        private void RegisterStartupTasks()
        {
            RegisterAllTypesBasedOn<IStartupTask>();
        }

        private void ExecuteStartupTasks()
        {
            IList<IStartupTask> startupTasks = _container.GetAllInstances<IStartupTask>();
            startupTasks.ForEach(x => x.Execute());
        }

        private void RegisterAllTypesBasedOn<T>()
        {
            _container.Configure(x => x.Scan(scan =>
            {
                scan.AssembliesFromApplicationBaseDirectory();
                scan.WithDefaultConventions();
                scan.AddAllTypesOf<T>();
            }));
        }

    }
}