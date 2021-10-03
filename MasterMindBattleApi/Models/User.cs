using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    public class User
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int GamesPlayed { get; set; }

        public int GamesWon { get; set; }

        public int GamewWonOnTime { get; set; }

        public CurrentUserStatus CurrentStatus { get; set; }
    }

    /// <summary>
    /// Current status of this user
    /// </summary>
    public class CurrentUserStatus
    {
        public UserStatus Status { get; set; }

        public string GameOrChallengeId { get; set; }

    }
}
