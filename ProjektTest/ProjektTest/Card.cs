using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektTest
{
    class Card
    {
        public enum CardValue
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
            Ace = 14
        }
        CardValue cardValue;

        public CardValue Value
        {
            get
            {
                return this.cardValue;
            }
            set
            {
                this.cardValue = value;
            }
        }

        public enum CardSuit
        {
            Hearts,
            Spades,
            Clubs,
            Diamonds
        }

        CardSuit cardSuit;
        public CardSuit Suit
        {
            get; set;
        }

        public Card(CardSuit Suit, CardValue Value)
        {
            cardValue = Value;
            cardSuit = Suit;

        }

        public override string ToString()
        {
            return cardSuit.ToString() + " " + cardValue.ToString();
        }


    }
}

