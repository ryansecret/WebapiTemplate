using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Ploeh.AutoFixture;
using Ryan.DomainModel.Ryan;

namespace Ryan.Unitest.Repository
{
    public class RyanRepository
    {
       [Test]
        public void Mock()
        {
            Fixture fixture=new Fixture();
            var ball= fixture .Create<MyClass>();
            int expectedNumber = fixture.Create<int>();
            var ryanRep = Substitute.For<IRyanRepository>();
            ryanRep.Hello().Returns("b");
            ryanRep.Hello().Should().Be("b");
        }

        public class MyClass
        {
             public string Name { get; set; }

             public int Age { get; set; }

            public Ryan Ryan { get; set; }
        }

        public class Ryan
        {
            public int dd { get; set; }
        }
    }
}