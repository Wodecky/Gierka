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
        public void ToStringTest()
        {
            //Arrange
            Mock<PlayerStatitics> stats = new Mock<PlayerStatitics>();
            Mock<Deck> deck = new Mock<Deck>();
            Player player = new Player(stats.Object, deck.Object, "trolololo");

            //Act
            string tostring = player.ToString();

            //Assert
            Assert.AreEqual(tostring, $"trolololo-> (Cards in hand: {player.CurrentHand[0]}, {player.CurrentHand[1]}, {player.CurrentHand[2]}) ( Mana: 0 / 0 ) ( HP: 30 / 30 )");
            
        }

        [Test()]
        public void DrawCardFromDeckTest()
        {
            //Arrange
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();

            Mock<IDeck> mock = new Mock<IDeck>();
            mock.Setup(x => x.IsEmpty()).Returns(false);
            mock.Setup(x => x.Draw()).Returns(3);

            IPlayer player = new Player(ps, mock.Object, "Marcin");

            //Act
            player.DrawCardFromDeck();

            //Assert
            Assert.AreEqual(4, player.CurrentHand.Count);
            Assert.AreEqual(3, player.CurrentHand[3]);
        }

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

        [Test()]
        public void GetHitTest()
        {
            //Arrange
            Mock<PlayerStatitics> stats = new Mock<PlayerStatitics>();
            Mock<Deck> deck = new Mock<Deck>();
            IPlayer player = new Player(stats.Object, deck.Object, "Marcin");

            //Act
            player.GetHit(5);

            //Assert
            Assert.AreEqual(25, player.PlayerStatistics.ActualHp);

        }

        [Test()]
        public void IsOverflowTest()
        {
            //Arrange



            //Act

            //Assert
        }
    }
}