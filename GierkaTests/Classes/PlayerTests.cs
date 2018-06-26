using NUnit.Framework;
using Gierka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gierka.Interfaces;
using Moq;

namespace Gierka.Classes.Tests
{
    [TestFixture()]
    public class PlayerTests
    {
        [Test()]
        public void InitializeTurnTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void ToStringTest()
        {
            Assert.Fail();
        }

        [Test()]
        public void PlayCardTest()
        {
            //Arrange
            Mock<PlayerStatitics> stats = new Mock<PlayerStatitics>();
            Mock<Deck> deck = new Mock<Deck>();
            IPlayer player = new Player(stats.Object, deck.Object, "Marcin");
            player.CurrentHand = new List<int>() { 1, 2, 3 };
            player.PlayerStatistics.ActualMana = 6;
            
            //Act
            player.PlayCard(1);

            //Assert
            Assert.AreEqual(player.CurrentHand, new List<int>() { 1, 3 });
            Assert.AreEqual(player.PlayerStatistics.ActualMana, 4);
            
        }
    }
}