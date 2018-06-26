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
        public string Name { get; set; }
        public IDeck Deck { get; set; }
        public IPlayerStatistics PlayerStatistics { get; set; }
        public List<int> CurrentHand { get; set; }

        public Player(IPlayerStatistics playerStatistics, IDeck deck, string name)
        {
            PlayerStatistics = playerStatistics;
            Deck = deck;
            Name = name;

            CurrentHand = new List<int>();
            for (int i = 0; i < 3; i++)
                CurrentHand.Add(Deck.Draw());

        }

        public void InitializeTurn()
        {
            PlayerStatistics.InitializeTurn(Deck);
            if(!Deck.IsEmpty()) Deck.Draw();
        }

        public override string ToString()
        {
            return $"{ Name } (Cards in hand: { string.Join(", ", CurrentHand) } )";
        }

        public int PlayCard(int cartIndex)
        {
            if (cartIndex <= CurrentHand.Count)
                return CurrentHand[cartIndex];
            return -1;
        }
    }
}
