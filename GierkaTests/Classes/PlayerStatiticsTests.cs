using NUnit.Framework;
using Gierka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace Gierka.Classes.Tests
{
    [TestFixture()]
    public class PlayerStatiticsTests
    {
        [Test()]
        public void InitializeTurnTest()
        {
            PlayerStatitics stats = new PlayerStatitics()
            {
                ActualMana = 4,
                ActualMaxMana = 6,
                ActualHp = 15
            };            
            Mock<Deck> deck = new Mock<Deck>();            

            stats.InitializeTurn(deck.Object);

            Assert.AreEqual(stats.ActualMaxMana, 7);
            Assert.AreEqual(stats.ActualMana, 7);
            Assert.AreEqual(stats.ActualHp, 15);


        }
    }
}