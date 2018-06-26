using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes
{
    public class PlayerStatitics : IPlayerStatistics
    {
        public PlayerStatitics()
        {
            ActualHp = MaxHp = 30;
            ActualMana = 0;
            MaxMana = 10;
        }

        public int ActualHp { get; set; }
        public int MaxHp { get; set; }
        public int ActualMana { get; set; }
        public int MaxMana { get; set; }

        public void InitializeTurn(IDeck deck)
        {
            
        }
    }
}
