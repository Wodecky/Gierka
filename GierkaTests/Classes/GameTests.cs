using NUnit.Framework;
using Gierka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gierka.Interfaces;

namespace Gierka.Classes.Tests
{
    [TestFixture()]
    public class GameTests
    {
        [Test()]
        public void SwapPlayerTest()
        {
            //Arrange
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player1 = new Player(ps, d, "Marcin");
            IPlayer player2 = new Player(ps, d, "Marcin");

            IGame game = new Game(player1, player2);

            //Act
            game.SwapPlayer();

            //Assert
            Assert.AreEqual(player2, game.ActualPlayer);
        }

        [Test()]
        public void GetOpponentTest()
        {
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player1 = new Player(ps, d, "Marcin");
            IPlayer player2 = new Player(ps, d, "Marcin");

            IGame game = new Game(player1, player2);

            //Act


            //Assert
            Assert.AreEqual(player2, game.ActualPlayer);
        }

        [Test()]
        public void GetWinnerTest()
        {
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player1 = new Player(ps, d, "Marcin");
            IPlayer player2 = new Player(ps, d, "Marcin");

            IGame game = new Game(player1, player2);

            //Act
            game.SwapPlayer();

            //Assert
            Assert.AreEqual(player2, game.ActualPlayer);
        }
    }
}