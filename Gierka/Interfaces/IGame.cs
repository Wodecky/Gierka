using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IGame
    {
        IPlayer ActualPlayer { get; set; }
        List<IPlayer> Players { get; set; }

        void StartGame(IPlayer player, IPlayerStatistics playerStatistics, IDeck deck);

    }
}
