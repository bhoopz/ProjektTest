using System;
using System.Collections.Generic;
using System.Text;

namespace ProjektTest
{
        class Game
        {
            private Player player;
            private Deck deck;
            private Hand hand;
            private Dealer dealer;
            public static double money;
            public Game()
            {
                this.player = new Player();
                this.deck = new Deck();
                this.hand = new Hand();
                this.dealer = new Dealer();
            }
            public void start()
            {

                money = 200;
                bool game = true;

                while (game)
                {
                    this.player = new Player();
                    this.deck = new Deck();
                    this.hand = new Hand();
                    this.dealer = new Dealer();
                    double bet = Betting(money);
                    Displaying(bet);
                }


            }
            private void PrintHand()
            {
                Console.WriteLine("Your hand: " + player.GetHand());
            }
            private void PrintDealerHand()
            {
                Console.WriteLine("Dealer hand: " + dealer.GetHand());
            }
            private static double Betting(double money)
            {
                bool betted = false;
                Console.WriteLine("Welcome to my casino");

                while (betted == false)
                {
                    Console.WriteLine("\n1.Bet\n2.Quit");
                    string choice = Console.ReadLine();
                    switch (choice)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("You have $" + money);
                            Console.WriteLine("How much you want to bet?");
                            try
                            {
                                double bet = Convert.ToDouble(Console.ReadLine());
                                if (bet > 0 && bet <= money)
                                {
                                    betted = true;
                                    return bet;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Error");
                                return 0;
                            }
                            break;

                        case "2":
                            Environment.Exit(0);
                            break;

                        default:
                            break;

                    }

                }
                return 0;
            }
            private void Displaying(double bet)
            {
                Card drawnCard;
                int sum = 0, sum2 = 0;
                bool playing = true;

                drawnCard = player.DrawCard(deck.GetCards());
                Console.WriteLine("Player draws: " + drawnCard);
                hand.AddValue(drawnCard, ref sum);

                drawnCard = dealer.DrawCard(deck.GetCards());
                Console.WriteLine("Dealer draws: " + drawnCard);
                hand.AddValue(drawnCard, ref sum2);

                drawnCard = player.DrawCard(deck.GetCards());
                Console.WriteLine("Player draws: " + drawnCard);
                hand.AddValue(drawnCard, ref sum);

                drawnCard = dealer.DrawCard(deck.GetCards());
                Console.WriteLine("Dealer draws.");
                hand.AddValue(drawnCard, ref sum2);

                Console.WriteLine("Value of your cards: " + sum);
                PrintHand();

                if (sum == 21 && sum2 == 21)
                {
                    PrintDealerHand();
                    Console.WriteLine("Draw!");
                }
                else if (sum == 21)
                {
                    PrintDealerHand();
                    money += -bet + 1.5 * bet;
                    Console.WriteLine("You win!");
                }
                else
                {
                    while (playing)
                    {
                        Console.WriteLine("\n1.Hit\n2.Stand");
                        string choice2 = Console.ReadLine();
                        switch (choice2)
                        {
                            case "1":
                                Console.Clear();
                                drawnCard = player.DrawCard(deck.GetCards());
                                Console.WriteLine("You draw: " + drawnCard);
                                hand.AddValue(drawnCard, ref sum);
                                Console.WriteLine("Value of your cards: " + sum);
                                PrintHand();
                                while (dealer.ShouldDraw(sum2))
                                {
                                    drawnCard = dealer.DrawCard(deck.GetCards());
                                    Console.WriteLine("Dealer draws.");
                                    hand.AddValue(drawnCard, ref sum2);
                                }
                                if (sum > 21)
                                {
                                    money -= bet;
                                    Console.WriteLine("Value greater than 21. You looose");
                                    playing = false;
                                }
                                break;
                            case "2":
                                while (dealer.ShouldDraw(sum2))
                                {
                                    drawnCard = dealer.DrawCard(deck.GetCards());
                                    Console.WriteLine("Dealer draws.");
                                    hand.AddValue(drawnCard, ref sum2);
                                }
                                Console.WriteLine("Value of dealers cards: " + sum2);
                                PrintDealerHand();
                                if (sum > sum2)
                                {
                                    money += -bet + 2 * bet;
                                    Console.WriteLine("You win!");
                                    playing = false;
                                }
                                else if (sum2 > sum && sum2 <= 21)
                                {
                                    money -= bet;
                                    Console.WriteLine("You lose!");
                                    playing = false;
                                }
                                else if (sum2 > 21 && sum < 21)
                                {
                                    money += -bet + 2 * bet;
                                    Console.WriteLine("You win!");
                                    playing = false;
                                }
                                else
                                {
                                    Console.WriteLine("Draw!");
                                    playing = false;
                                }
                                break;
                            case "":
                                Console.WriteLine("Enter a choice");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }

