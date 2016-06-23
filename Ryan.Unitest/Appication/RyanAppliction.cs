using FluentAssertions;
using Microsoft.Practices.ServiceLocation;
using NUnit.Framework;
using Ryan.Application;

namespace Ryan.Unitest.Appication
{
    public class RyanApplictionTest:ApplicationTestBase
    {
        [Test]
        public void RyanTest()
        {
           var result= ServiceLocator.Current.GetInstance<RyanApplication>().Hello();
           result.Should().NotBeEmpty();
        }
    }
}