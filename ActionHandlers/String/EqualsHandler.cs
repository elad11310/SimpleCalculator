using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.String
{
    public class EqualsHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {
            return (action.OperandA.Equals(action.OperandB)).ToString();
        }
    }
}
