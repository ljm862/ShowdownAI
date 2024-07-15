using Microsoft.AspNetCore.Mvc;
using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Implementations;

namespace ShowdownAI.Middleware.Controllers
{
    [ApiController]
    [Route("api/showdown")]
    public class ShowdownController() : Controller
    {
        private static readonly MoveSelector _moveSelector = new MoveSelector();

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
            var newMove = await Task.Run(() => _moveSelector.RunPrediction());
            return newMove;
        }

    }
}
