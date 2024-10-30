using Microsoft.AspNetCore.Mvc;
using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services.Interfaces;

namespace ShowdownAI.Middleware.Controllers
{
    [ApiController]
    [Route("api/showdown")]
    public class ShowdownController : Controller
    {
        private readonly IMoveDataLookup _moveDataLookup;
        private readonly IMoveSelector _moveSelector;
        private readonly IBattleTracker _battleTracker;
        private readonly ITypeLookup _typeLookup;

        public ShowdownController(IMoveDataLookup moveDataLookup, IMoveSelector moveSelector, IBattleTracker battleTracker, ITypeLookup typeLookup)
        {
            _moveDataLookup = moveDataLookup;
            _moveSelector = moveSelector;
            _battleTracker = battleTracker;
            _typeLookup = typeLookup;
        }

        [HttpGet]
        [Route("test")]
        public int Test()
        {
            return 1;
        }

        [HttpGet]
        [Route("moveDataLookup/{id}")]
        public MoveData GetMoveInfoById(string id)
        {
            return _moveDataLookup.GetMoveData(id);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("update")]
        public async Task<IActionResult> UpdateBattle([FromBody] string updateString)
        {
            _battleTracker.Update(updateString);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Route("act")]
        public async Task<IActionResult> NewTurn([FromBody] SideStatusRequest sideStatusRequest)
        {
            _moveSelector.BuildPrediction(sideStatusRequest);
            return Ok(await RunPrediction());
        }

        private async Task<ShowdownAction> RunPrediction()
        {
            return await _moveSelector.RunPrediction();
        }

    }
}
