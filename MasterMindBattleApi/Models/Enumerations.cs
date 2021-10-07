using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Status of a game.
    /// </summary>
    public enum GameStatus
    {
        /// <summary>
        /// Game is in progress
        /// </summary>
        InProgress,
        /// <summary>
        /// The game has ended by the user resigning
        /// </summary>
        UserResigned,
        /// <summary>
        /// The game has ended by the user having lost
        /// </summary>
        UserLost,
        /// <summary>
        /// The game has ended by the user having won
        /// </summary>
        UserWon
    } 

    /// <summary>
    /// Move made by user
    /// </summary>
    public enum MoveType
    {
        /// <summary>
        /// User is submitting a guess
        /// </summary>
        Guess,
        /// <summary>
        /// User is giving up
        /// </summary>
        GiveUp
    }

    /// <summary>
    /// Type of the game
    /// </summary>
    public enum GameType
    {
        Normal,
        Speed
    }
    /// <summary>
    /// Users status
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// User is off line
        /// </summary>
        OffLine,
        /// <summary>
        /// User is online
        /// </summary>
        OnLine,
        /// <summary>
        /// User is participating in a challenge
        /// </summary>
        InChallenge,
        /// <summary>
        /// User is participating in a regular game
        /// </summary>
        InGame
    }
}
