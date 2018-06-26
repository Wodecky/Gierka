﻿using Gierka.Interfaces;
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


                int playedCardPower = 0;
                while(playedCardPower != -1)
                {
                    Console.Write("Wybór karty nr ( -1 aby pominąć turę ): ");
                    playedCardPower = ActualPlayer.PlayCard(int.Parse(Console.ReadLine()));

                }
                if(playedCardPower != -1)
                    GetOpponent().PlayerStatistics.ActualHp -= playedCardPower;

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
            return Players.First(x => x.PlayerStatistics.ActualHp > 0);
        }
    }
}
