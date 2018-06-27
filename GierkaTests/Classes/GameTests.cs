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
            IPlayer player2 = new Player(ps, d, "Maciej");

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
            IPlayer player2 = new Player(ps, d, "Maciej");

            IGame game = new Game(player1, player2);

            //Act
            var actual = game.GetOpponent();

            //Assert
            Assert.AreEqual(player2, actual);
        }

        [Test()]
        public void GetWinnerTest()
        {
            IPlayerStatistics ps1 = new PlayerStatitics();
            IPlayerStatistics ps2 = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player1 = new Player(ps1, d, "Marcin");
            IPlayer player2 = new Player(ps2, d, "Maciej");
            player2.PlayerStatistics.ActualHp = 0;


            IGame game = new Game(player1, player2);

            //Act
            var actual = game.GetWinner();

            //Assert
            Assert.AreEqual(player1, actual);
        }

        [Test()]
        public void GameTest()
        {
            //Arrange
            IGame game;
            IPlayer player = new Player(new PlayerStatitics(), new Deck(), "test");
            IPlayer player2 = new Player(new PlayerStatitics(), new Deck(), "test2");

            //Act
            game = new Game(player, player2);

            //Assert
            Assert.AreEqual(player, game.ActualPlayer);
            Assert.AreEqual(player, game.Players[0]);
            Assert.AreEqual(player2, game.Players[1]);
        }
    }
}