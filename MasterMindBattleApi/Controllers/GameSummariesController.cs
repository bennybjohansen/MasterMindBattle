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
        /// <param name="InProgress">
        ///   - Limits response to games which are in progress (default is false)
        /// </param>
        /// <param name="top">
        /// Max number to return
        /// </param>
        /// <param name="skip">
        /// </param>
        /// Start from record number
        /// <returns></returns>
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
            var openApiUserList = new OpenApiList<User>();
            openApiUserList.BuildFromDataAndQueryParams(Request, gameSummaries);
            return Ok(openApiUserList);
        }

        private List<GameSummary> GetMockData(string userId, DateTime fromDate, bool inProgress)
        {

            List<GameSummary> gamesummaries = new List<GameSummary>();
            gamesummaries.Add(
                new GameSummary
                {
                    UserId = "UserId1",
                    Name = "Benny Bomstærk",
                    Picture = "no picture",
                    GamesPlayed = 20,
                    GamesWon = 8,
                    GamewWonOnTime = 3,
                    CurrentStatus = new CurrentUserStatus
                    {
                        Status = UserStatus.InGame,
                        GameOrChallengeId = "2"
                    }
                }
                );
            users.Add(
                new User
                {
                    UserId = "UserId13",
                    Name = "Fedtmule",
                    Picture = "no picture",
                    GamesPlayed = 10,
                    GamesWon = 2,
                    GamewWonOnTime = 3,
                    CurrentStatus = new CurrentUserStatus
                    {
                        Status = UserStatus.InGame,
                        GameOrChallengeId = "2"
                    }
                }
                );
            if (returnAll)
            {
                users.Add(
                                new User
                                {
                                    UserId = "UserId11",
                                    Name = "SuperNullen",
                                    Picture = "no picture",
                                    GamesPlayed = 10,
                                    GamesWon = 9,
                                    GamewWonOnTime = 0,
                                    CurrentStatus = new CurrentUserStatus
                                    {
                                        Status = UserStatus.OffLine,
                                    }
                                }
                );
            }
            return (gamesummaries);
        }

    }
}
