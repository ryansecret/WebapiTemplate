using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Ryan.DomainModel;
using Ryan.DomainModel.Ryan;

namespace Ryan.Unitest.Model
{
    public class Ball
    {
        [Test]
        public void Test()
        {
            BallValidator validator=new BallValidator();
            var result = validator.Validate(new BallEntity());
            result.IsValid.Should().BeFalse();
            var ball = new BallEntity();
            ball.IsValid().Should().BeFalse();
            ball.ValidationState.Should().NotBeNull();
        }
    }
}
