using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Represents a move on a game
    /// </summary>
    public class GameMoveRequest
    {
        //The choice made by the user
        public MoveType MoveType { get; set; }

        //The value of the guess if MoveType = Guess
        public int[]? Guess { get; set; }
    }
}
