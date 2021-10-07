using MasterMindBattleApi.Helpers;
using MasterMindBattleApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteStatisticsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<SiteStatistics> Get(bool ReturnAll = false, int top = 10, int skip = 0)
        {
            SiteStatistics siteStatistics;

            int mockDataId = 0;
            //Fetch data (maybe mock data)
            if (OpenApiHelpers.UseMockData(Request, ref mockDataId))
            {
                siteStatistics = GetMockData();
            }
            else
            {
                return StatusCode(501, "This is not yet implemented");
            }
            return Ok(siteStatistics);
        }

        private SiteStatistics GetMockData()
        {
            var s = new SiteStatistics()
            {
                NoOfGamesPlayed = 1001,
                NoOfOnlineUsers =3,
                NoOfRegisteredUsers=50,
                TopPlayers= new UserSummary[]
                {
                    new UserSummary(){UserId = "UserId1", Name = "Benny Bomstærk" },
                    new UserSummary(){UserId = "UserId11", Name = "SuperNullen" }
                }
            };
            return s;
        }
    }
}
