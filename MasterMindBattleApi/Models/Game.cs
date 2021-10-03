using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    public class Game
    {
        public string GameId { get; set; }

        public GameStatus GameStatus { get; set; }

        public GameType GameType { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int[] Answer { get; set; }

        public GameRow[] Rows { get; set; }

    }

    public class GameRow
    {
        public int[] Guess { get; set; }
        public RowScore Score { get; set; }
    }

    public class RowScore
    {
        public int NoOfCorrectColors { get; set; }
        public int NoOfCorrectLocations { get; set; }
    }
}
