using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCalculator.Models
{
    public class ActionHistory
    {
        [Key]
        public int Id { get; set; }

        //Setting ActionId as a foreign key in ActionHistory table by EF
        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        // This tells to the Model.Isvalid in the server side to ignore this
        //  [ValidateNever]
        public CalculatorAction Action { get; set; }

        public string Result { get; set; }

        public DateTime ExecuteTime { get; set; }


    }
}
