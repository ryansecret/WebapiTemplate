using System.ComponentModel;
using FluentValidation;
using FluentValidation.Results;

namespace Ryan.DomainModel.Ryan
{
    public class BallEntity:BaseEntity
    {
        public BallEntity()
        {
            
        }
        public BallEntity(string name,string color)
        {
            this.Name = name;
            this.Color = color;
        }
        [DisplayName("姓名")]
        public string Name { get; private set; }

        public string Color { get; private set; }


        protected override IValidator GetValidator()
        {
             return new BallValidator();
        }
    }
}