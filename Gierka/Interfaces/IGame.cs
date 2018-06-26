using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IGame
    {
        int CurrentTurn { get; set; }
        IPlayer ActualPlayer { get; set; }
        List<IPlayer> Players { get; set; }

        void StartGame();
        void InitializeTurn();
        void SwapPlayer();

    }
}
