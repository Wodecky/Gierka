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

        public IPlayer ActualPlayer { get; set; }
        public List<IPlayer> Players { get; set; }

        public void InitializeTurn()
        {
            ActualPlayer.InitializeTurn();
        }

        public void StartGame()
        {
            while(!IsEndOfTheGame())
            {
                InitializeTurn();



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
