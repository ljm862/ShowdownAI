﻿using Microsoft.AspNetCore.Mvc;
using ShowdownAI.Middleware.Models;
using ShowdownAI.Middleware.Services;
using ShowdownAI.Middleware.Services.Implementations;

namespace ShowdownAI.Middleware.Controllers
{
    [ApiController]
    [Route("api/showdown")]
    public class ShowdownController() : Controller
    {
        private static readonly MoveSelector _moveSelector = new MoveSelector();
        private static readonly MoveDataLookup _moveDataLookup = new MoveDataLookup();

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
