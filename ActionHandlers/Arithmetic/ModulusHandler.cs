using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.Arithmetic
{
    public class ModulusHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {
            if (double.TryParse(action.OperandA, out double num1) && double.TryParse(action.OperandB, out double num2))
            {
                double res = num1 % num2;
                return res.ToString();


            }
            else
            {
                return "Invalid input. Both strings should represent valid integers.";
            }
        }
    }
}
