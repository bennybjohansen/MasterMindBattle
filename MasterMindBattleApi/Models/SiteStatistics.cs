using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Site statistics
    /// </summary>
    public class SiteStatistics
    {
        /// <summary>
        /// Number of games played by all players on site
        /// </summary>
        public int NoOfGamesPlayed { get; set; }

        /// <summary>
        /// Number of registered users
        /// </summary>
        public int NoOfRegisteredUsers { get; set; }

        /// <summary>
        /// Number of users online
        /// </summary>
        public int NoOfOnlineUsers { get; set; }

        /// <summary>
        /// Summary table of best players
        /// </summary>
        public UserSummary[] TopPlayers { get; set; }

    }

    /// <summary>
    /// Summary information about a user
    /// </summary>
    public class UserSummary
    {
        /// <summary>
        /// Unique id for user
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Users name
        /// </summary>
        public string Name { get; set; }
    }
}
