using NUnit.Framework;
using Gierka.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes.Tests
{
    [TestFixture()]
    public class DeckTests
    {
        [Test()]
        public void IsEmptyTest_Empty()
        {
            Deck deck = new Deck();
            bool wynik;

            wynik = deck.IsEmpty();

            Assert.AreEqual(false, wynik);
        }

        [Test()]
        public void DrawTest()
        {
            List<int> list = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            Deck deck = new Deck();

            int card = deck.Draw();

            Assert.Contains(card, list);
        }
    }
}
