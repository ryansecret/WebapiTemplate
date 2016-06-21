#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Ryan.Core.DependencyManagement;

#endregion

namespace Ryan.Core
{
    /// <summary>
    ///     Engine
    /// </summary>
    public class WorkEngine
    {
        #region Properties

        /// <summary>
        ///     Container manager
        /// </summary>
        protected readonly IContainer _containerManager;

        #endregion

        public WorkEngine(IContainer container)
        {
            _containerManager = container;
        }

        #region Utilities

        /// <summary>
        ///     Run startup tasks
        /// </summary>
        protected virtual void RunStartupTasks()
        {
            var typeFinder = _containerManager.Resolve<ITypeFinder>();
            var startUpTaskTypes = typeFinder.FindClassesOfType<IStartupTask>();
            var startUpTasks = startUpTaskTypes.Select(startUpTaskType => (IStartupTask) Activator.CreateInstance(startUpTaskType)).ToList();

            startUpTasks = startUpTasks.AsQueryable().OrderBy(st => st.Order).ToList();
            foreach (var startUpTask in startUpTasks)
                startUpTask.Execute();
        }

        /// <summary>
        ///     Runs the aysnc startup tasks.
        /// </summary>
        protected virtual void RunAysncStartupTasks()
        {
           
           var startUpTasks = ResolveAll<IAsyncStartupTask>().ToList();
           Parallel.ForEach(startUpTasks, d => d.Execute());
           
        }


        /// <summary>
        ///     Register dependencies
        /// </summary
        protected virtual void RegisterDependencies()
        {
            //dependencies
            var builder = new ContainerBuilder();


            builder.RegisterType<WebAppTypeFinder>().As<ITypeFinder>();
            builder.Update(_containerManager);

            //register dependencies provided by other assemblies
            var typeFinder = _containerManager.Resolve<ITypeFinder>();
            builder = new ContainerBuilder();
            //var drTypes = typeFinder.FindClassesOfType<IDependencyRegister>();
            //var drInstances = new List<IDependencyRegister>();
            //foreach (var drType in drTypes)
            //    drInstances.Add((IDependencyRegister) Activator.CreateInstance(drType));
            ////sort
            //drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            //foreach (var dependencyRegistrar in drInstances)
            //    dependencyRegistrar.Register(builder, typeFinder);
            
            var types= typeFinder.FindClassesEndWith(new[] {"Repository", "Application"});
            foreach (var type in types)
            {
                builder.RegisterType(type).SingleInstance();
            }
            builder.Update(_containerManager);
        }

        #endregion

        #region Methods

        /// <summary>
        ///  初始化
        /// </summary>
        public void Initialize()
        {
            RegisterDependencies();

            RunStartupTasks();
            RunAysncStartupTasks();
        }


        /// <summary>
        ///     Resolve dependencies
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        private T[] ResolveAll<T>()
        {
            return _containerManager.Resolve<IEnumerable<T>>().ToArray();
        }

        #endregion
    }
}