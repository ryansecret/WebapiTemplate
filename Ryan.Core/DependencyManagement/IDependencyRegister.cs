#region



#endregion

using Autofac;

namespace Ryan.Core.DependencyManagement
{
    public interface IDependencyRegister
    {
        int Order { get; }
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);
    }
}