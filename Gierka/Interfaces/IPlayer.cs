using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IPlayer
    {
        IDeck Deck { get; set; }
        List<int> CurrentHand { get; set; }
        IPlayerStatistics PlayerStatistics { get; set; }
        void InitializeTurn();

    }
}
