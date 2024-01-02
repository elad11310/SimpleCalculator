using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleCalculator.Data;
using SimpleCalculator.Interfaces;
using SimpleCalculator.Models;
namespace SimpleCalculator.Controllers.api
{
    [ApiController]

    public class OperationsController : Controller
    {

        // Using DI to inject the db instance by the services container in Program.cs
        private readonly ApplicationDbContext _db;
        private readonly IActionHandler _actionHandler;
        public OperationsController(ApplicationDbContext db, IActionHandler actionHandler)

        {
            _db = db;
            _actionHandler = actionHandler;
        }


        // [controller] - placeholder in the route attribute which is a token that gets replaced with the name of the controller
        [HttpGet]
        [Route("api/[controller]/GetAllOperations")]
        public IActionResult GetAllOperations()
        {
            try
            {
                var actions = _db.Actions
                  .Select(action => action.Operation)
                  .Distinct()
                  .ToList();


                return Json(new { data = actions });
            }
            catch (Exception ex)
            {
                return ReturnServerResponse(500, "An error occurred while processing your request.");
            }


        }


        [HttpGet]
        [Route("api/[controller]/GetHistoricData")]
        public IActionResult GetHistoricData(string operation)
        {
            // Getting all the history of the action

            if (string.IsNullOrEmpty(operation))
            {
                return NotFound();
            }

            ActionHistoryResponseModel responseObj = new ActionHistoryResponseModel();


            int? actionId = GetOperationId(operation);

            if (actionId == null)
            {
                return NotFound();
            }

            try
            {
                // Also passing Action as property to include the Action which is a foreign key
                IEnumerable<ActionHistory> actionHistory =
                  GetActionsBasedOnFilter(
                   action => action.ActionId == actionId,
                   "Action"

                  );


                // Monthly actions count
                responseObj.MonthActions = actionHistory?
                  .Count(action => DateTime.UtcNow.Month == action.ExecuteTime.Month);


                // Last 3 actions details
                responseObj.LastThreeActions = actionHistory?
                    .OrderByDescending(action => action.ExecuteTime)
                    .Take(3)
                    .ToList();




                // Most popular action
                var mostPopular = _db.ActionHistory
                .GroupBy(action => action.ActionId)
                .OrderByDescending(group => group.Count())
                .Select(group => new { ActionId = group.Key, Count = group.Count() })
                .ToList();

                if (mostPopular != null && mostPopular.Count > 0)
                {

                    // Check if there are some actions that repeated the most and at the same count
                    // If so return the last one executed as most popular

                    int maxRepeated = mostPopular.Max(a => a.Count);

                    // Filtering according to the max repeated action
                    mostPopular = mostPopular.Where(a => a.Count == maxRepeated).ToList();
                    int mostPopularId = mostPopular.First().ActionId;
                    if (mostPopular.Count > 1)
                    {

                        var mostPopularActionIds = mostPopular.Select(item => item.ActionId).ToList();


                        mostPopularId = _db.ActionHistory
                           .Where(a => mostPopularActionIds.Contains(a.ActionId))
                           .OrderByDescending(action => action.ExecuteTime)
                           .Take(1).FirstOrDefault().ActionId;


                    }

                    responseObj.MostPopular = _db.Actions
                                 .Where(a => a.Id == mostPopularId)
                                 .Select(a => a.Operation).FirstOrDefault();


                }


                return Json(new { data = responseObj });
            }
            catch (Exception e)
            {
                return ReturnServerResponse(500, $"An error occurred while processing your request.");
            }


        }



        [HttpPost]
        [Route("api/[controller]/Execute")]
        public async Task<IActionResult> Execute([FromBody] ActionRequestModel request)
        {
            string result = string.Empty;


            try
            {

                result = _actionHandler.Execute(request);
                await SaveResult(request.Operation, result);
                return Json(new { data = result });


            }

            catch (ArgumentException e)
            {
                return ReturnServerResponse(400, e.Message);
            }
            catch (InvalidOperationException e)
            {
                return ReturnServerResponse(400, e.Message);
            }
            catch (Exception e)
            {
                return ReturnServerResponse(500, "An error occurred while processing your request.");
            }

          
        }

        private async Task SaveResult(string operation, string result)
        {
            var operationId = GetOperationId(operation);

            _db.ActionHistory.Add(new ActionHistory
            {
                ActionId = operationId,
                ExecuteTime = DateTime.UtcNow,
                Result = result
            });

            await _db.SaveChangesAsync();
        }

        private int GetOperationId(string operation)
        {
            return _db.Actions
                 .Where(action => action.Operation == operation)
                 .Select(action => action.Id)
                 .FirstOrDefault();
        }

        private IEnumerable<ActionHistory> GetActionsBasedOnFilter(Func<ActionHistory, bool> filter, string includeProp)
        {
            var filteredActions = _db.ActionHistory
                .Include(includeProp)
                .Where(filter)
                .ToList();

            return filteredActions;
        }

        private ObjectResult ReturnServerResponse(int errorCode, string errorMsg)
        {
            var errorResponse = new
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMsg,

            };
            return StatusCode(errorCode, errorResponse);
        }

    }
}
