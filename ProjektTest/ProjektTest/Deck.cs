using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjektTest
{
    class Deck
    {
        

            private List<Card> cards = new List<Card>();

            public Deck()
            {
                AddToDeck();

            }

            public void AddToDeck()
            {
                foreach (Card.CardSuit suit in Enum.GetValues(typeof(Card.CardSuit)))
                {
                    foreach (Card.CardValue value in Enum.GetValues(typeof(Card.CardValue)))
                    {
                        cards.Add(new Card(suit, value));
                    }
                }

                Random r = new Random();
                cards = cards.OrderBy(x => r.Next()).ToList();


            }

            public List<Card> GetCards()
            {
                return cards;
            }

        }
    }

