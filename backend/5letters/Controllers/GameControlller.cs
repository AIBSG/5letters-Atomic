using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using _5letters.Models;
using _5letters.Services;

namespace _5letters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        
        private readonly ILogger<GameController> _logger;

        public static Game NowGame = new Game
        {
            CorrectWord = "носок",
            Date = DateTimeOffset.Now,
            GameStage = GameStages.GameInProgress,
            Id = 228,
            Words = new List<Word>(),
            UserId = Guid.Empty
        };

        // public GameController (ILogger<GameController> logger)
        // {
        //     _logger = logger;
        // }
        //
        // [HttpPost]
        // public string GameProcess([FromBody] string nowWord)
        // {
        //     Game result = GameService.RunGame(NowGame, nowWord);
        //     return "aaa";
        // }
        [HttpPost]
        public IActionResult GetWord(string nowWord)
        {
            GameService runGame = new GameService();
            NowGame = runGame.RunGame(NowGame, nowWord);
            return Ok(NowGame);
        }

         [HttpGet]
        public IActionResult ReturnWord()
        {
            return Ok(NowGame);
        }
        


    }
}