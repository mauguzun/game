using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Contracts;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : Controller
    {
        private readonly IGame _game;
        private readonly IUserResult _userResult;
        private readonly int bestPlayerCount = 3;
        public GameController(IGame game, IUserResult userResult)
        {
            _game = game;
            _userResult = userResult;
        }

        [HttpGet]
        public IActionResult Index()
        {
            _game.StartGame();
            return Ok();
        }

        [HttpGet("{bet}")]
        public IActionResult Index(bool bet) => Ok(JsonConvert.SerializeObject(_game.Bet(bet)));

        [HttpPost]
        public IActionResult Index([FromBody]User user)
        {
            var result = _game.GetGameResult(user);
            _userResult.SaveUser(result);
            return Ok(_userResult.BestPlayers(bestPlayerCount));
        }

    }
}
