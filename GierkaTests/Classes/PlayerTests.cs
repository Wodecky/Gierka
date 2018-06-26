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
            IPlayerStatistics ps = new PlayerStatitics();
            IDeck d = new Deck();
            IPlayer player = new Player(ps, , "Marcin");



            //Act

            //Assert


        }
    }
}