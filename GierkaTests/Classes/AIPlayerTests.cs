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
    public class AIPlayerTests
    {
        [Test()]
        public void GetChoiceTest()
        {
            //Arrange
            PlayerStatitics stats = new PlayerStatitics();
            Deck deck = new Deck();
            IPlayer player = new AIPlayer(stats, deck, "Bot");
            player.CurrentHand = new List<int>() { 4, 4, 2, 5 };
            player.PlayerStatistics.ActualMana = 8;

            //Act
            int result = int.Parse(player.GetChoice());
            int result2 = int.Parse(player.GetChoice());

            //Assert
            Assert.AreEqual(4, result);
            Assert.AreEqual(4, result2);
        }

        [Test()]
        public void GetChoiceTest2()
        {
            //Arrange
            PlayerStatitics stats = new PlayerStatitics();
            Deck deck = new Deck();
            IPlayer player = new AIPlayer(stats, deck, "Bot");
            player.CurrentHand = new List<int>() { 2, 3, 4, 6, 7 };
            player.PlayerStatistics.ActualMana = 8;

            //Act
            int result = int.Parse(player.GetChoice());
            player.PlayCard(result);
            int result2 = int.Parse(player.GetChoice());
            player.PlayCard(result2);

            //Assert
            Assert.AreEqual(6, result);
            Assert.AreEqual(2, result2);
        }
    }
}