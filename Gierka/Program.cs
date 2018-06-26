using Gierka.Classes;
using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka
{
    class Program
    {
        static void Main(string[] args)
        {
            IPlayer playerLeft = new Player(new PlayerStatitics(), new Deck());
            IPlayer playerRight = new Player(new PlayerStatitics(), new Deck());

            IGame game = new Game(playerLeft, playerRight);

            game.StartGame();
        }
    }
}
