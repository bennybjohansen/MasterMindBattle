using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Represents a summary of a game.
    /// </summary>
    public class GameSummary
    {
        /// <summary>
        /// Id of the game
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Current status of the game
        /// </summary>
        public GameStatus GameStatus { get; set; }

        /// <summary>
        /// Type of game
        /// </summary>
        public GameType GameType { get; set; }

        /// <summary>
        /// Current row number of the game
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// Current row including guess and score
        /// </summary>
        public GameRow CurrentRow { get; set; }
        /// <summary>
        /// Summary of the user playing this game
        /// </summary>
        public UserSummary[] Players { get; set; }
    }

   
}
