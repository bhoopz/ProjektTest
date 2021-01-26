using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektTest
{
    class Hand
    {
        private List<Card> cards;
        public Hand()
        {
            this.cards = new List<Card>();
        }
        public void AddCard(Card card)
        {
            cards.Add(card);
        }
        public void AddValue(Card drawn, ref int sum)
        {

            if (drawn.Value == Card.CardValue.Jack || drawn.Value == Card.CardValue.King || drawn.Value == Card.CardValue.Queen)
            {
                sum += 10;
            }
            else if (drawn.Value == Card.CardValue.Ace)
            {
                if (sum <= 10)
                {
                    sum += 11;
                }
                else
                {
                    sum += 1;
                }
            }
            else
            {
                sum += (int)drawn.Value;
            }

        }

        public override string ToString()
        {
            string cardsString = String.Join(", ", cards);
            return cardsString;
        }




    }
}

