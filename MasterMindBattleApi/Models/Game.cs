using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Represents a game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Id of the game
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Status of the game
        /// </summary>
        public GameStatus GameStatus { get; set; }

        /// <summary>
        /// Type of the game
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        /// Start time of game
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Time the game ended
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Correct answer for this game
        /// </summary>
        public int[] Answer { get; set; }

        /// <summary>
        /// A list of rows which have been played on this game so far
        /// </summary>
        public GameRow[] Rows { get; set; }

    }

    /// <summary>
    /// Represents a row of a game
    /// </summary>
    public class GameRow
    {
        /// <summary>
        /// Guess made by user
        /// </summary>
        public int[] Guess { get; set; }
        /// <summary>
        /// Scoring of this guess
        /// </summary>
        public RowScore Score { get; set; }
    }

    /// <summary>
    /// The score for a guess
    /// </summary>
    public class RowScore
    {
        /// <summary>
        /// Number of correct colors, which are also not on the correct location
        /// </summary>
        public int NoOfCorrectColors { get; set; }
        /// <summary>
        /// Number of correct colors which are also on the correct location.
        /// </summary>
        public int NoOfCorrectLocations { get; set; }
    }
}
