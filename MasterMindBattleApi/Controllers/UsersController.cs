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
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<OpenApiList<User>> Get(bool ReturnAll = false, int top=10, int skip=0)
        {
            int mockDataId = 0;
            List<User> users = null;

            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                users = GetMockData(ReturnAll);
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }

            //Convert to OpenApi list format and return
            var openApiUserList = new OpenApiList<User>();
            openApiUserList.BuildFromDataAndQueryParams(Request, users);
            return Ok(openApiUserList);
        }

        private List<User> GetMockData(bool returnAll)
        {

            List<User> users = new List<User>();
            users.Add(
                new User
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
            return (users);
        }

    }
}
