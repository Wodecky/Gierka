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
        public IPlayer ActualPlayer { get; set; }
        public List<IPlayer> Players { get; set; }

        public void StartGame(IPlayer player, IPlayerStatistics playerStatistics, IDeck deck)
        {
            while(!IsEndOfTheGame())
            {

            }
        }

        private bool IsEndOfTheGame()
        {
            if (Players.Any(x => x.PlayerStatistics.ActualHp == 0))
                return true;
            return false;
        }
    }
}
