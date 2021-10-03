using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    public class SiteStatistics
    {
        public int NoOfGamesPlayed { get; set; }

        public int NoOfRegisteredUsers { get; set; }

        public int NoOfOnlineUsers { get; set; }

        public UserSummary[] TopPlayers { get; set; }

    }

    public class UserSummary
    {
        public string UserId { get; set; }

        public string Name { get; set; }
    }
}
