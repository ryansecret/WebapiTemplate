using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ryan.Controller;
using Ryan.DomainModel.Ryan;

namespace Ryan.Unitest.Repository
{
    public class RyanRepository
    {
        [Test]
        public void Mock()
        {
           
            var ryanRep = Substitute.For<IRyanRepository>();
            ryanRep.Hello().Returns("b");
            ryanRep.Hello().Should().Be("b");
        }
    }
}