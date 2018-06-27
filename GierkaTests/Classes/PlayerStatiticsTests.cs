using NUnit.Framework;
using Gierka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Gierka.Interfaces;

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
        [Test()]
        public void InitializeTurnTest_Bleeding()
        {
            //Arrange
            PlayerStatitics stats = new PlayerStatitics()
            {
                ActualMana = 4,
                ActualMaxMana = 6,
                ActualHp = 15
            };
            Mock<IDeck> deck = new Mock<IDeck>();
            deck.Setup(x => x.IsEmpty()).Returns(true);

            //Act
            stats.InitializeTurn(deck.Object);


            //Assert
            Assert.AreEqual(14, stats.ActualHp);

        }

        [Test()]
        public void PlayerStatiticsTest_MaxActualMana()
        {
            //Arrange
            PlayerStatitics stats = new PlayerStatitics()
            {
                ActualMana = 4,
                ActualMaxMana = 6,
                ActualHp = 15
            };

            //Act
            stats.ActualMaxMana = 50;


            //Assert
            Assert.AreEqual(10, stats.ActualMaxMana);

        }

        [Test()]
        public void PlayerStatiticsTest()
        {
            //Arrange
            PlayerStatitics stats;

            //Act
            stats = new PlayerStatitics();

            //Assert
            Assert.AreEqual(30, stats.MaxHp);
            Assert.AreEqual(30, stats.ActualHp);
            Assert.AreEqual(0, stats.ActualMana);
            Assert.AreEqual(0, stats.ActualMaxMana);
        }
    }
}