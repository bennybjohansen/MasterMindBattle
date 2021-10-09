using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterMindBattleApi.Models;
using MasterMindBattleApi.Helpers;

namespace MasterMindBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        /// <summary>
        /// Returns details of a specific game:
        /// </summary>
        /// <param name="GameId">
        /// Id of the Game. Caller must be associated with game or caller must be an administrator
        /// </param>
        /// <returns></returns>
        [HttpGet("{GameId}")]
        public ActionResult<Game> Get(string GameId)
        {
            int mockDataId = 0;
            Game game = null;

            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                game = GetMockData(GameId);
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }
            return Ok(game);
        }


        /// <summary>
        /// Creates a new game
        /// </summary>
        /// <returns></returns>
        [HttpPost("")]
        public ActionResult<NewGameResponse> Post(string GameId)
        {
            int mockDataId = 0;
            NewGameResponse newGameResponse = null;

            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                newGameResponse = GetNewGameMockData();
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }
            return Created("",newGameResponse);
        }

        /// <summary>
        /// Register a new move on the specified game
        /// </summary>
        /// <returns></returns>
        [HttpPost("{GameId}/moves")]
        public ActionResult<GameMoveResponse> Post(string GameId, GameMoveRequest GameMoveRequest)
        {
            int mockDataId = 0;
            GameMoveResponse gameMoveResponse = null;

            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                gameMoveResponse = GetGameMoveMockData(GameId,GameMoveRequest);
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }
            return Created("", gameMoveResponse);
        }

        private GameMoveResponse GetGameMoveMockData(string gameId,GameMoveRequest gameMoveRequest)
        {
            var gmr = new GameMoveResponse();
            gmr.GameId = gameId;
            gmr.RowNo = 1;
            if (gameMoveRequest.MoveType==MoveType.Guess)
            {
                gmr.GameStatus = GameStatus.InProgress;
                gmr.Guess = gameMoveRequest.Guess;
                gmr.Answer = new int[] { 1, 2, 3, 4 };
                gmr.Score = new RowScore() { NoOfCorrectColors = 1, NoOfCorrectLocations = 1 };
            }
            else
            {
                gmr.GameStatus = GameStatus.UserResigned;
            }
            return (gmr);
        }

        private NewGameResponse GetNewGameMockData()
        {
            var ngr = new NewGameResponse()
            {
                GameId = "GameId4",
                GameStatus = GameStatus.InProgress,
                RowNo = 0
            };
            return ngr;
        }


        //TODO:Should there not also be a UserId returned together with a Game?
        private Game GetMockData(string gameId)
        {
            Game game = new Game()
            {
                GameId = gameId,
                GameStatus = GameStatus.InProgress,
                GameType = GameType.Normal,
                StartTime = new DateTime(2021, 10, 09),
                Answer = new int[]{ 1,3,4,1},
                Rows = new GameRow[]
                {
                    new GameRow()
                    {
                        Guess = new int[] { 0, 1, 2, 3 },
                        Score = new RowScore() { NoOfCorrectColors = 2, NoOfCorrectLocations = 0 }
                    },
                    new GameRow()
                    {
                        Guess = new int[] { 1, 1, 1, 1 },
                        Score = new RowScore() { NoOfCorrectColors = 0, NoOfCorrectLocations = 2 }
                    },
                    new GameRow()
                    {
                        Guess = new int[] { 1, 3, 4, 0 },
                        Score = new RowScore() { NoOfCorrectColors = 0, NoOfCorrectLocations = 3 }
                    },
                }
            };
            return (game);
        }

    }
}
