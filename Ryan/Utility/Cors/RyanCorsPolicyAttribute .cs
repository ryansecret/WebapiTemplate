using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace Ryan.Utility.Cors
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false)]
    public class RyanCorsPolicyAttribute :Attribute,ICorsPolicyProvider
    {
        private CorsPolicy _policy;
        public RyanCorsPolicyAttribute()
        {
            
            _policy = new CorsPolicy
            {
                AllowAnyMethod = true,
                AllowAnyHeader = true,
                
            };
            _policy.Origins.Add(".*");
        }
        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
           return Task.FromResult(_policy);
        }
    }
}