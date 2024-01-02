using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCalculator.Models
{
    public class CalculatorAction
    {
        // Using [Key] data annotation to set Id as a primary key 

        [Key]
        public int Id { get; set; }

        public string Description { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Operation { get; set; }


    }
}
