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
            if (string.IsNullOrWhiteSpace(name))
                name = Guid.NewGuid().ToString("N");

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
            {
                if (IsOverflow())
                    Deck.Draw();
                else
                    CurrentHand.Add(Deck.Draw());

            }
        }

        public override string ToString()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write(Name);
            Console.ResetColor();
            
            return $" -> (Cards in hand: { string.Join(", ", CurrentHand) } ) (Mana: { PlayerStatistics.ActualMana } / { PlayerStatistics.ActualMaxMana } ) (HP: { PlayerStatistics.ActualHp } / { PlayerStatistics.MaxHp } )";
        }

        public int PlayCard(int cardChoice)
        {
            if (cardChoice < 0)
                return -1;

            if (CurrentHand.Any(x => x == cardChoice))
            {
                int res = CurrentHand.First(x => x == cardChoice);
                if(res <= PlayerStatistics.ActualMana)
                {
                    CurrentHand.Remove(res);
                    PlayerStatistics.ActualMana -= res;
                    return res;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Zbyt mało many!");
                    Console.ResetColor();
                    return -2;
                }

            }
            return -1;
        }

        public void GetHit(int value)
        {
            PlayerStatistics.ActualHp -= value;
        }

        public bool IsOverflow()
        {
            return CurrentHand.Count >= 5;
        }
    }

}
