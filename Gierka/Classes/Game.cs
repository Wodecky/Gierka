using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes
{
    public class Game : IGame
    {
        public Game(IPlayer playerLeft, IPlayer playerRight)
        {
            Players.Add(playerLeft);
            Players.Add(playerRight);
            ActualPlayer = Players[0];
        }

        public int CurrentTurn { get; set; } = -1;
        public IPlayer ActualPlayer { get; set; }
        public List<IPlayer> Players { get; set; } = new List<IPlayer>();

        public void InitializeTurn()
        {
            ActualPlayer.InitializeTurn();


        }

        public void StartGame()
        {
            while(!IsEndOfTheGame())
            {
                InitializeTurn();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Tura { CurrentTurn++ }:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(ActualPlayer.ToString());

                Console.Write("Wybór karty nr: ");
                ActualPlayer.PlayCard(int.Parse(Console.ReadLine()));

                Console.ResetColor();
                SwapPlayer();
            }
        }

        public void SwapPlayer()
        {
            ActualPlayer = Players.First(x => x.Name != ActualPlayer.Name);
        }

        private bool IsEndOfTheGame()
        {
            if (Players.Any(x => x.PlayerStatistics.ActualHp == 0))
                return true;
            return false;
        }
    }
}
