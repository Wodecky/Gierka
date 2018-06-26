using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes
{
    public class Player : IPlayer
    {
        public IDeck Deck { get; set; }
        public IPlayerStatistics PlayerStatistics { get; set; }
        public List<int> CurrentHand { get; set; }

        public Player(IPlayerStatistics playerStatistics, IDeck deck)
        {
            PlayerStatistics = playerStatistics;
            Deck = deck;

        }

        public void InitializeTurn()
        {
            PlayerStatistics.InitializeTurn(Deck);
            Deck.Draw();
        }
    }
}
