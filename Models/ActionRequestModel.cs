using System.ComponentModel.DataAnnotations;

namespace SimpleCalculator.Models
{
    public class ActionRequestModel
    {

        public string? OperandA { get; set; }
        public string? OperandB { get; set; }
        public string? Operation { get; set; }
    }
}
