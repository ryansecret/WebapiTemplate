using System.Runtime.CompilerServices;
using FluentValidation;

namespace Ryan.DomainModel.Ryan
{
    public class BallValidator: AbstractValidator<BallEntity>
    {
        public BallValidator()
        {
            this.RuleFor(d => d.Name).NotEmpty().WithErrorCode("100");
        }
    }
}