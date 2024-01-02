using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.String
{
    public class IndexOfHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {
            return (action.OperandA.IndexOf(action.OperandB)).ToString();
        }
    }
}
