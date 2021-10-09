using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterMindBattleApi.Models
{
    /// <summary>
    /// Describes new game. Returned in response to new game creation
    /// </summary>
    public class NewGameResponse
    {
        /// <summary>
        /// Id of newly created game
        /// </summary>
        public string GameId { get; set; }

        /// <summary>
        /// Status of newly created game - will always be "InProgress"
        /// </summary>
        public GameStatus GameStatus { get; set; }

        /// <summary>
        /// Row number of newly created game - will always be 0
        /// </summary>
        public int RowNo { get; set; }
    }
}
