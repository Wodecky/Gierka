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

        public void InitializeStatistics()
        {
            PlayerStatistics.InitializeTurn(Deck);
        }

        public void DrawCardFromDeck()
        {
            if(!Deck.IsEmpty())
                CurrentHand.Add(Deck.Draw());
        }

        public override string ToString()
        {
            return $"{ Name } -> (Cards in hand: { string.Join(", ", CurrentHand) } ) (Mana: { PlayerStatistics.ActualMana } / { PlayerStatistics.ActualMaxMana } ) (HP: { PlayerStatistics.ActualHp } / { PlayerStatistics.MaxHp } )";
        }

        public int PlayCard(int cartIndex)
        {
            if (cartIndex < 0)
                return -1;
            cartIndex = cartIndex - 1;

            if (cartIndex <= CurrentHand.Count)
            {
                int res = CurrentHand[cartIndex];
                if(res <= PlayerStatistics.ActualMana)
                {
                    CurrentHand.RemoveAt(cartIndex);
                    PlayerStatistics.ActualMana -= res;
                    return res;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zbyt malo many!");
                    Console.ResetColor();
                }

            }
            return -1;
        }
    }
}
