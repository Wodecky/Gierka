using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        IDeck Deck { get; set; }
        List<int> CurrentHand { get; set; }
        IPlayerStatistics PlayerStatistics { get; set; }

        void InitializeStatistics();
        void DrawCardFromDeck();
        int PlayCard(int cartIndex);
        void GetHit(int value);
    }
}
