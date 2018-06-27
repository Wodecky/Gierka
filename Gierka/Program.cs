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
            Console.Write("Nick gracza nr 1: ");
            string name1 = Console.ReadLine();
            Console.Write("Nick gracza nr 2: ");
            string name2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name1))
                name1 = Guid.NewGuid().ToString("N");
            if (string.IsNullOrWhiteSpace(name2))
                name2 = Guid.NewGuid().ToString("N");

            IPlayer playerLeft = new Player(new PlayerStatitics(), new Deck(), name1);
            IPlayer playerRight = new Player(new PlayerStatitics(), new Deck(), name2);

            IGame game = new Game(playerLeft, playerRight);

            game.StartGame();

            Console.ReadKey();
        }
    }
}
