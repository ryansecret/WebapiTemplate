using Autofac.Extras.DynamicProxy2;
using Ryan.Application.Models.Converter;
using Ryan.Core.Intercepters;
using Ryan.Model;

namespace Ryan.Application
{
    [Intercept(typeof(LogIntercepter))]
    public class RyanApplication
    {
        private readonly IRyanRepository _ryanRepository;

        public RyanApplication(IRyanRepository ryanRepository)
        {
            _ryanRepository = ryanRepository;
        }

        public virtual string Hello()
        {
           
            return _ryanRepository.Hello();
        }
    }
   
}