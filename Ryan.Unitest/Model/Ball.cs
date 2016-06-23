using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using Ryan.Application.Models.Converter;
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
        [Test]
        public void Converter()
        {
            new AutoMapperStartupTask().Execute();
            var ball = Create();
            ball.ToBall().Should().NotBeNull().Should();

            var balls= new BallEntity[] {ball}.ToList().ToBalls();
           
            balls.Should().NotBeNull();
        }

        BallEntity Create()
        {return new BallEntity("ryan","bb");}
    }
}
