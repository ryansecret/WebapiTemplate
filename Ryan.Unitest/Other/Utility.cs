using System.Net;
using FluentAssertions;
using NUnit.Framework;
using Ryan.Utility;

namespace Ryan.Unitest.Other
{
    public class Utility
    {
        [Test]
        public void WebClientTest()
        {
            //WebClient client = new WebClient();
            //var dd = client.GetData<int[]>("http://localhost:30663/api/Values/Ryan", 5).Result;
            //dd.Should().NotBeNull();
            WebClient client = new WebClient();
            var dd = client.GetData<int[]>("http://localhost:9802/api/Ryan/RyanTest", "adf").Result;
            dd.Should().NotBeNull();
        }
    }
}