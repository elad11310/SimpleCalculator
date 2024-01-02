using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCalculator.Models
{
    public class CalculatorAction
    {
        // Using [Key] data annotation to set Id as a primary key 

        [Key]
        public int Id { get; set; }

        public string Descirption { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Operation { get; set; }


    }
}
