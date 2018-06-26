using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Interfaces
{
    public interface IPlayerStatistics
    {
        int ActualHp { get; set; } 
        int MaxHp { get; }
        
        
        int ActualMana { get; set; }
        int ActualMaxMana { get; set; }


        void InitializeTurn(IDeck deck);
    }
}
