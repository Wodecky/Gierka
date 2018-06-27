using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes
{
    public class AIPlayer : IPlayer
    {
        public AIPlayer(IPlayerStatistics playerStatistics, IDeck deck, string name)
        {
            Deck = deck;
            PlayerStatistics = playerStatistics;
            Name = name;

            CurrentHand = new List<int>();
            for (int i = 0; i < 3; i++)
                CurrentHand.Add(Deck.Draw());
        }

        public string Name { get; set; }
        public IDeck Deck { get; set; }
        public List<int> CurrentHand { get; set; }
        public IPlayerStatistics PlayerStatistics { get; set; }

        public void DrawCardFromDeck()
        {
            if (!Deck.IsEmpty())
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
            Console.WriteLine();
            Console.Write(Name);
            Console.ResetColor();

            return $" -> (Cards in hand: { string.Join(", ", CurrentHand) } ) (Mana: { PlayerStatistics.ActualMana } / { PlayerStatistics.ActualMaxMana } ) (HP: { PlayerStatistics.ActualHp } / { PlayerStatistics.MaxHp } )";
        }

        public string GetChoice()
        {
            List<int> smallerChoice = CurrentHand.Where(x => x <= PlayerStatistics.ActualMana).ToList();

            if (smallerChoice.Count <= 0)
                return string.Empty;
            if (smallerChoice.Contains(0))
                return "0";

            if (smallerChoice.Any(x => x == PlayerStatistics.ActualMana))
                return smallerChoice.First(x => x == PlayerStatistics.ActualMana).ToString();

            int HigherToLower = 0;
            int LowerToHigher = 0;

            int tempMana = PlayerStatistics.ActualMana;

            List<int> replica = new List<int>(smallerChoice);

            while(replica.Any())
            {
                if(replica.Max() <= tempMana)
                {
                    HigherToLower += replica.Max();
                    tempMana -= replica.Max();
                }
                replica.Remove(replica.Max());
            }

            replica = new List<int>(smallerChoice);
            tempMana = PlayerStatistics.ActualMana;

            while (replica.Any())
            {
                if (replica.Min() <= tempMana)
                {
                    LowerToHigher += replica.Min();
                    tempMana -= replica.Min();
                }
                replica.Remove(replica.Min());
            }

            return HigherToLower >= LowerToHigher ? smallerChoice.Max().ToString() : smallerChoice.Min().ToString();
        }

        public void GetHit(int value)
        {
            PlayerStatistics.ActualHp -= value;
        }

        public void InitializeStatistics()
        {
            PlayerStatistics.InitializeTurn(Deck);
        }

        public bool IsOverflow()
        {
            return CurrentHand.Count >= 5;
        }

        public int PlayCard(int cardChoice)
        {
            if (cardChoice < 0)
                return -1;

            if (CurrentHand.Any(x => x == cardChoice))
            {
                int res = CurrentHand.First(x => x == cardChoice);
                if (res <= PlayerStatistics.ActualMana)
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
    }
}
