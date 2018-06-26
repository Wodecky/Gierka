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
        private const int TOTALMAXMANA = 10;
        public const int MAXHP = 30;
        private int actualMaxMana;

        public PlayerStatitics()
        {
            ActualHp = MAXHP;
            ActualMana = 0;
            ActualMaxMana = 0;            
        }

        public int ActualHp { get; set; }

        public int ActualMaxMana
        {
            get
            {
                return actualMaxMana;
            }
            set
            {
                if (value > TOTALMAXMANA)
                {
                    actualMaxMana = 10;
                }
                else
                    actualMaxMana = value;
            }
        }
        public int ActualMana { get; set; }

        public int MaxHp
        {
            get
            {
                return MAXHP;
            }
        }

        public void InitializeTurn(IDeck deck)
        {
            ActualMaxMana++;
            ActualMana = ActualMaxMana;
            if (deck.IsEmpty())
            {
                ActualHp--;
            }
                        
        }
    }
}
