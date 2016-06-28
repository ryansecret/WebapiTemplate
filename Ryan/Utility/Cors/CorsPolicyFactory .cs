using System.Net.Http;
using System.Web.Http.Cors;

namespace Ryan.Utility.Cors
{
    public class CorsPolicyFactory :ICorsPolicyProviderFactory
    {
        public ICorsPolicyProvider GetCorsPolicyProvider(HttpRequestMessage request)
        {
            return new RyanCorsPolicyAttribute();
        }
    }
}