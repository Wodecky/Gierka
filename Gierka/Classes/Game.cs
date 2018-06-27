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

        public int CurrentTurn { get; set; } = 0;
        public IPlayer ActualPlayer { get; set; }
        public List<IPlayer> Players { get; set; } = new List<IPlayer>();

        public void InitializeTurn()
        {
            ActualPlayer.DrawCardFromDeck();
            ActualPlayer.InitializeStatistics();


        }

        public void StartGame()
        {
            while(!IsEndOfTheGame())
            {
                InitializeTurn();
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("--------------------------------------------------------------------------------------------");
                Console.ResetColor();

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Tura { CurrentTurn++ }:");



                int playedCardPower = 0;
                while(playedCardPower != -1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ActualPlayer.ToString());
                    Console.Write($"Wybór karty nr: ");

                    string wybor = ActualPlayer.GetChoice();
                    if (string.IsNullOrWhiteSpace(wybor))
                        break;

                    playedCardPower = ActualPlayer.PlayCard(int.Parse(wybor));
                    if (playedCardPower > 0)
                    {
                        GetOpponent().GetHit(playedCardPower);
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{ GetOpponent().Name } dostał obrażenia równe { playedCardPower }");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                    if (ActualPlayer.PlayerStatistics.ActualMana <= 0 || playedCardPower == -1 || playedCardPower == -2)
                        playedCardPower = -1;

                    if (GetWinner() != null)
                        break;

                    
                }


                Console.ResetColor();
                SwapPlayer();
            }
            Console.WriteLine();
            Console.WriteLine($"Koniec gry, zwyciężył gracz { GetWinner().Name }");
        }

        public void SwapPlayer()
        {
            ActualPlayer = Players.First(x => x.Name != ActualPlayer.Name);
        }

        public IPlayer GetOpponent()
        {
            return Players.First(x => x.Name != ActualPlayer.Name);
        }

        private bool IsEndOfTheGame()
        {
            if (Players.Any(x => x.PlayerStatistics.ActualHp <= 0))
                return true;
            return false;
        }

        public IPlayer GetWinner()
        {
            if (Players.Any(x => x.PlayerStatistics.ActualHp <= 0))
                return Players.FirstOrDefault(x => x.PlayerStatistics.ActualHp > 0);
            else
                return null;
        }
    }
}
