using System.ComponentModel.DataAnnotations;

namespace Ryan.Application.Models
{
    public class Ball
    {
        public string Name { get;   set; }
        [Required]
        public string Color { get;   set; }
    }
}