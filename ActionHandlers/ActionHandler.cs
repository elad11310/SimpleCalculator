using SimpleCalculator.ActionHandlers.Arithmetic;
using SimpleCalculator.ActionHandlers.String;
using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;

namespace SimpleCalculator.ActionHandlers
{
    public class ActionHandler : IActionHandler
    {

        private readonly Dictionary<string, IActionHandler> _handlers = new Dictionary<string, IActionHandler>();

        public ActionHandler()
        {
            InitializeHandlers();
        }


        private void InitializeHandlers()
        {
            _handlers.Add(Operation.Addition.ToString().ToLower(), new AdditionHandler());
            _handlers.Add(Operation.Subtraction.ToString().ToLower(), new SubtractionHandler());
            _handlers.Add(Operation.Multiplication.ToString().ToLower(), new MultiplicationHandler());
            _handlers.Add(Operation.Division.ToString().ToLower(), new DivisionHandler());
            _handlers.Add(Operation.Power.ToString().ToLower(), new PowerHandler());
            _handlers.Add(Operation.Modulus.ToString().ToLower(), new ModulusHandler());
            _handlers.Add(Operation.Compare.ToString().ToLower(), new CompareHandler());
            _handlers.Add(Operation.Concatenate.ToString().ToLower(), new ConcatenateHandler());
            _handlers.Add(Operation.Contains.ToString().ToLower(), new ContainsHandler());
            _handlers.Add(Operation.Equals.ToString().ToLower(), new EqualsHandler());
            _handlers.Add(Operation.IndexOf.ToString().ToLower(), new IndexOfHandler());
        }




        public dynamic Execute(ActionRequestModel action)
        {
            if (_handlers.TryGetValue(action.Operation.ToLower(), out var handler))
            {
                return handler.Execute(action);
            }
            else
            {
                
                throw new InvalidOperationException($"Operation {action.Operation} is not supported");
            }
        }
    }
}
