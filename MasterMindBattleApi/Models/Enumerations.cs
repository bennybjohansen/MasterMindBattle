using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    public enum GameStatus
    {
        InProgress,
        UserResigned,
        UserLost,
        UserWon
    } 

    public enum MoveType
    {
        Guess,
        GiveUp
    }

    public enum GameType
    {
        Normal,
        Speed
    }

    public enum UserStatus
    {
        OffLine,
        OnLine,
        InChallenge,
        InGame
    }
}
