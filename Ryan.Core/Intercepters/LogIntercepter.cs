using System.Linq;
using Castle.DynamicProxy;
using Ryan.Core.Log;

namespace Ryan.Core.Intercepters
{
    public class LogIntercepter:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
             
            invocation.Proceed();
            
            if (!invocation.Method.IsConstructor&&invocation.Method.IsPublic)
            {
                $"方法{invocation.Method.Name}--参数：{ string.Join(", ", invocation.Arguments.Select(a => (a ?? "").ToString()).ToArray())},结果：{invocation.ReturnValue}".LogInfo();
            }
            
        }
    }
}