using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Represents a user of this game.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unique identification for the user.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// User name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Url to picture
        /// </summary>
        public string? Picture { get; set; }

        /// <summary>
        /// Total number of games played
        /// </summary>
        public int GamesPlayed { get; set; }

        /// <summary>
        /// Total number of games won
        /// </summary>
        public int GamesWon { get; set; }

        /// <summary>
        /// Total number of games won on time
        /// </summary>
        public int GamewWonOnTime { get; set; }

        /// <summary>
        /// This users current status.
        /// </summary>
        public CurrentUserStatus CurrentStatus { get; set; }
    }

    /// <summary>
    /// Current status of this user
    /// </summary>
    public class CurrentUserStatus
    {
        /// <summary>
        /// Users status
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Reference to game or challenge if user is playing
        /// </summary>
        public string GameOrChallengeId { get; set; }

    }
}
