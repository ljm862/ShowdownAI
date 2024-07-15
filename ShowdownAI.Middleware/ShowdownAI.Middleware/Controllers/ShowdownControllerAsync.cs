using Microsoft.AspNetCore.Mvc;
using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Implementations;

namespace ShowdownAI.Middleware.Controllers
{
    [ApiController]
    [Route("api/async/showdown")]
    public class ShowdownControllerAsync() : Controller
    {
        private static readonly MoveSelectorAsync _moveSelector = new MoveSelectorAsync();

        [HttpGet]
        public int Test()
        {
            return 1;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("banana")]
        public async Task<IActionResult> NewTurn([FromBody] SideStatusRequest sideStatusRequest)
        {
            _moveSelector.BuildPrediction(sideStatusRequest);
            return Ok(await RunPrediction());
        }

        private async Task<ShowdownAction> RunPrediction()
        {
            // Will run the prediction on a separate thread so the response won't time out to whoever called the endpoint.
            _ = Task.Run(() => _moveSelector.RunPrediction());
            return ShowdownAction.Error;
        }

    }
}
