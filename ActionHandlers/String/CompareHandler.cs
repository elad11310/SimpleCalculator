using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers.String
{
    public class CompareHandler : IActionHandler
    {
        dynamic IActionHandler.Execute(ActionRequestModel action)
        {

            switch (action.OperandA.CompareTo(action.OperandB))
            {
                case 0:
                    return action.OperandA;
                case 1:
                    return action.OperandB;
                case -1:
                    return action.OperandA;
                default:
                    return "";
            }

        }
    }
}
