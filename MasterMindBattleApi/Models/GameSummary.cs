using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    public class GameSummary
    {
        public string GameId { get; set; }

        public GameStatus GameStatus { get; set; }

        public GameType GameType { get; set; }

        public int RowNo { get; set; }
        public GameRow CurrentRow { get; set; }
        public UserSummary[] Players { get; set; }
    }

   
}
