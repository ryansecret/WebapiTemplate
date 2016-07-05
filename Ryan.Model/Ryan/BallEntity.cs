using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Castle.Core.Internal;
using FluentValidation;
using FluentValidation.Results;

namespace Ryan.DomainModel.Ryan
{
    [Table("Ball")]
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

        public int Id { get; private set; }

        [MaxLength(150)]
        [DisplayName("姓名")]
        public string Name { get; private set; }
        [MaxLength(150)]
        public string Color { get; private set; }


        protected override IValidator GetValidator()
        {
             return new BallValidator();
        }
    }
}