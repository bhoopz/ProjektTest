using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektTest
{
    class Player
    {
        private Hand hand = new Hand();
        public Card DrawCard(List<Card> cards)
        {
            int index = cards.Count() - 1;

            Card card = cards[index];

            this.hand.AddCard(card);

            cards.RemoveAt(index);

            return card;
        }
        public Hand GetHand()
        {
            return hand;
        }
    }
}
