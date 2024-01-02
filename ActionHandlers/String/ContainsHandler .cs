using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.String
{
    public class ContainsHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {
            return (action.OperandA.Contains(action.OperandB)).ToString();
           

        }
    }
}
