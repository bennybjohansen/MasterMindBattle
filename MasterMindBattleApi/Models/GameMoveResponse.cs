using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Represents what is being returned after a user has made a move on a specified game
    /// </summary>
    public class GameMoveResponse
    {
        /// <summary>
        /// The Id of the game
        /// </summary>
        public string GameId { get; set; }
        /// <summary>
        /// The current status of the game
        /// </summary>
        public GameStatus GameStatus { get; set; }
        /// <summary>
        /// The current row number of the game
        /// </summary>
        public int RowNo { get; set; }
        /// <summary>
        /// Return of users guess, if callers MoveType was guess
        /// </summary>
        public int[]? Guess { get; set; }
        /// <summary>
        /// Score for submitted Guess if MoveType was guess
        /// </summary>
        public RowScore? Score { get; set; }
        /// <summary>
        /// Answer will only be retuned if answer is guessed, or GameStatus is no longer in progress
        /// </summary>
        public int[]? Answer { get; set; }

    }
}
