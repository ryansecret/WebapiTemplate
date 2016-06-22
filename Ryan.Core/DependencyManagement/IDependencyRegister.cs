#region

#endregion

using Autofac;
using Daisy.Core;

namespace Ryan.Core.DependencyManagement
{
    public interface IDependencyRegister
    {
        int Order { get; }
        void Register(ContainerBuilder builder, ITypeFinder typeFinder);
    }
}