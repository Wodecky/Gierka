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
            Assert.Fail();
        }

        [Test()]
        public void PlayCardTest()
        {
            //Arrange
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player = new Player(ps, d, "Marcin");


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

    }
}