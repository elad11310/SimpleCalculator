using SimpleCalculator.Models;

namespace SimpleCalculator.Interfaces
{
    public interface IActionHandler
    {
        dynamic Execute(ActionRequestModel action);
    }
}
