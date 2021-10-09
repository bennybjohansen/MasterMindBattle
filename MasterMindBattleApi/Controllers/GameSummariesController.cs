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
    public class GameSummariesController : ControllerBase
    {
        /// <summary>
        /// Returns a list of summaries for games based on user, status and dates.
        /// By default the list is limited to:
        ///  - if the caller is administrator:all users
        ///  - else the caller.
        /// Paging is supported.
        /// </summary>
        /// <param name="UserId">
        ///   - Limits response to those played by the specified user.
        /// </param>
        /// <param name="FromDate">
        ///   - Limits response to games started after the specified date.
        /// </param>
        /// <param name="InProgress">
        ///   - Limits response to games which are in progress (default is false)
        /// </param>
        /// <param name="top">
        /// Max number to return
        /// </param>
        /// <param name="skip">
        /// Start from record number
        /// </param>
        /// 
        /// 
        /// <returns/>
        /// 

        [HttpGet]
        public ActionResult<OpenApiList<GameSummary>> Get(string UserId, DateTime FromDate, bool InProgress = false, 
            int top=10, int skip=0)

        {
            int mockDataId = 0;
            List<GameSummary> gameSummaries = null;

            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                gameSummaries = GetMockData(UserId, FromDate,InProgress);
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }

            //Convert to OpenApi list format and return
            var openApiGameSummaryList = new OpenApiList<GameSummary>();
            openApiGameSummaryList.BuildFromDataAndQueryParams(Request, gameSummaries);
            return Ok(openApiGameSummaryList);
        }

        private List<GameSummary> GetMockData(string userId, DateTime fromDate, bool inProgress)
        {

            List<GameSummary> gamesummaries = new List<GameSummary>();
            gamesummaries.Add(
                new GameSummary
                {
                    GameId = "GameId1",
                    GameStatus = GameStatus.InProgress,
                    GameType = GameType.Normal,
                    RowNo = 3,
                    CurrentRow = new GameRow()
                    {
                        Guess = new int[] { 0, 1, 2, 3, 4 },
                        Score = new RowScore() { NoOfCorrectColors = 2, NoOfCorrectLocations = 1 }
                    },
                    Players = new UserSummary[] { new UserSummary() { UserId = "UserId13", Name = "Fedtmule" } }
                });

            if (!inProgress)
            {
                gamesummaries.Add(
                new GameSummary
                {
                    GameId = "GameId19",
                    GameStatus = GameStatus.InProgress,
                    GameType = GameType.Normal,
                    RowNo = 3,
                    CurrentRow = new GameRow()
                    {
                        Guess = new int[] { 0, 1, 2, 3},
                        Score = new RowScore() { NoOfCorrectColors = 2, NoOfCorrectLocations = 1 }
                    },
                    Players = new UserSummary[] { new UserSummary() { UserId = "UserId11", Name = "SuperNullen" } }
                });

            }
            return (gamesummaries);
        }

    }
}
