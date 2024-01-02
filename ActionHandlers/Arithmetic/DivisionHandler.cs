using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.Arithmetic
{
    public class DivisionHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {
            if (double.TryParse(action.OperandA, out double num1) && double.TryParse(action.OperandB, out double num2))
            {
                if (num2 == 0)
                {
                    throw new ArgumentException("Can't divide by 0");
                }
                double res = num1 / num2;
                return res.ToString();


            }
            else
            {   
                throw new ArgumentException("Invalid input. Both strings should represent valid integers.");
            }
        }
    }
}
