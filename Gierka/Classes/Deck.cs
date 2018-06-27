using Gierka.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gierka.Classes
{
    public class Deck : IDeck
    {
        private List<int> allcards;
        

        public Deck()
        {
            allcards = new List<int>() { 0, 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 5, 5, 6, 6, 7, 8 };
        }

        

        public int Draw()
        {
            int card = GetCard();
            RemoveCard(card);
            return card;
        }

        private void RemoveCard(int card)
        {
            allcards.Remove(card);
        }

        private int GetCard()
        {
            Random rand = new Random();
            return allcards[rand.Next(0, allcards.Count - 1)];
        }

        public bool IsEmpty()
        {
            return allcards.Count == 0;
        }

    }
}
