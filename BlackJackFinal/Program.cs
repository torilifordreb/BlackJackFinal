using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable to hold users choice to hit or stand
            string hitStandChoice;
            //variable to holds the users choice to continue or not
            string strContinue = "Y";



            //new array to hold DeckInUse of cards
            List<Card> deckOfCards = new List<Card>(5);
            //counter integer
            int m = 0;

            if (m <= 51)
            {
                //outer loop for setting card suit
                for (int i = 0; i <= 3; i++) 
                {
                    //nested loop for setting card faces
                    for (int j = 0; j <= 12; j++)
                    {
                        deckOfCards.Add(new Card((Suit) i, (Face) j));
                        //Console.WriteLine(deckOfCards[m].ToString());
                        m++;
                    }
                }
            }



            //create a new PlayerOne object
            Player playerOne = new Player();
            //create new computer player object
            Computer compPlayer = new Computer();

            //welcome user and ask for Name
            Console.WriteLine("\nWelcome to the table. What is your name?");
            //set answer to PlayerOne Name
            playerOne.SetName(Console.ReadLine());

            //ask user for amount to put on books
            Console.WriteLine("\nNice to meet you, " + playerOne.GetName() + ". \nYou must now add funds to your account.");
            Console.WriteLine("\nEnter $$ amount: ");
            //set answer to PlayerOne bank account
            playerOne.SetInTheBank(Convert.ToInt32(Console.ReadLine()));

            //while PlayerOne chooses to continue and they have money in the bank
            while (strContinue == "Y" && playerOne.GetInTheBank() > 0)
            {
                //Game Begins

                //ask PlayerOne for bet amount
                Console.WriteLine(playerOne.GetName() + ", enter your bet amount for this game: ");
                playerOne.SetPlayerBet(Convert.ToInt32(Console.ReadLine()));
                //subtract bet amount from total in the bank
                playerOne.SetInTheBank(playerOne.GetInTheBank() - playerOne.GetPlayerBet());
                //computer matches the bet
                compPlayer.SetInTheBank(compPlayer.GetInTheBank() - playerOne.GetPlayerBet());




                //SECTION FOR MULTIPLE DECKS


                //create variable for do/while loop
                int y = 0;
                int deckNum;
                //do while loop to ensure they choose an appropriate amount of decks.
                do
                {
                    Console.WriteLine("How many decks would you like to play with? (1-3)");
                    deckNum = Convert.ToInt32(Console.ReadLine());
                    if (deckNum < 1 || deckNum > 3)
                    {
                        Console.WriteLine("Invalid entry.");
                    }
                    else
                    {
                        Console.WriteLine("You will be playing with " + deckNum + " decks.");

                        y++;
                    }
                }
                while (y < 1);


                //create decks based on deckNum entered
                List<Card> allDecks = new List<Card>();

                switch (deckNum)
                {
                    case 2:
                        //concat deckOfCards to itself for 2 decks
                        deckOfCards.AddRange(deckOfCards);
                        break;
                    case 3:
                        //concat deckOfCards to itself twice for 3 decks
                        deckOfCards.AddRange(deckOfCards);
                        deckOfCards.AddRange(deckOfCards);
                        break;
                    default:
                        //nothing changes, the deckOfCards is already established
                        break;
                }//end multi-deck section


                //create new deck with allDecks as the card array and playerOne as the PlayerOne
                Deck deckInUse = new Deck(deckOfCards, playerOne, compPlayer);

                //shuffle all the decks to be played with
                deckInUse.Shuffle();


                //in this section i will start to print the table/draw cards
                //loop for actual game play

                for (int i = 0; i < 1; i++)
                {

                    //prints header and computer's bet and balance
                    Console.WriteLine("\n\n\tCOMPUTER\t|\t" + playerOne.GetName() + "\t\t\t" + playerOne.GetName() + "'s Bet: "
                        + playerOne.GetPlayerBet() + "\t\tComp.'s Bet: " + playerOne.GetPlayerBet());
                    //prints separator and player's bet and balance
                    Console.WriteLine("_________________________________________________\t" + playerOne.GetName() + "'s Balance: " + 
                        playerOne.GetInTheBank() + "\tComp.'s Balance: " + compPlayer.GetInTheBank());

                
                    //first deal (computer and PlayerOne) + show scores
                    Console.WriteLine("\t" + deckInUse.DealCardFaceDown() + "\t|\t" + deckInUse.PlayerDealCard());
                    Console.WriteLine(deckInUse.computerDealCard() + "\t|\t" + deckInUse.PlayerDealCard() +  "\t" +
                        playerOne.GetName() + "'s Score: " + playerOne.GetCurrentScore() + "\tComp.'s Score: " + compPlayer.GetCurrentScore());



                    //check for blackjack or bust
                    if (deckInUse.ChkPlayerBlackJack() == true)
                    {
                        i++;  //leave the loop
                    }
                    if (deckInUse.ChkComputerBlackJack() == true)
                    {
                        i++;  //leave the loop
                    }
                    if (deckInUse.ChkPlayerBust() == true)
                    {
                        i++;  //leave the loop
                    }
                    if (deckInUse.ChkComputerBust() == true)
                    {
                        i++;  //leave the loop
                    }
                    //if no busts or blackjacks
                    else if (deckInUse.ChkPlayerBlackJack() == false && deckInUse.ChkPlayerBust() == false && deckInUse.ChkComputerBlackJack() == false && deckInUse.ChkComputerBust() == false)
                    {
                        do
                        {
                            //ask if player would like to hit or stand
                            Console.WriteLine("\t\t\t|\t\t\t\tWould you like to hit or stand? (H/S)");
                            Console.Write("\t\t\t|\t\t\t\t");
                            hitStandChoice = Console.ReadLine();

                            //if chooses hit, hit once, then ask again
                            if (hitStandChoice == "H" || hitStandChoice == "h")
                            {
                                //hit card
                                Console.WriteLine("\t\t\t|\t" + deckInUse.PlayerDealCard() + "\t" +
                                    playerOne.GetName() + "'s Score: " + playerOne.GetCurrentScore() + "\tComp.'s Score: " + compPlayer.GetCurrentScore());

                                //check for bust/blackjack after each card
                                if (deckInUse.ChkPlayerBlackJack() == true)
                                {
                                    i++;  //leave the loop
                                }
                                if (deckInUse.ChkPlayerBust() == true)
                                {
                                    i++;  //leave the loop
                                }
                            }
                            else if (hitStandChoice == "s" || hitStandChoice == "S")
                            {
                                //while computer total score is less than 18, continue to draw
                                while (compPlayer.GetCurrentScore() + compPlayer.GetFaceDownScore() < 18)
                                { 
                                    Console.WriteLine(deckInUse.computerDealCard() + "\t|\t\t\t\t" + playerOne.GetName() + "'s Score: " + playerOne.GetCurrentScore() +
                                        "\tComp.'s Score: " + compPlayer.GetCurrentScore());

                                    //check computer scores
                                    if (deckInUse.ChkComputerBlackJack() == true)
                                    {
                                        i++;  //leave the loop
                                    }
                                    else if (deckInUse.ChkComputerBust() == true)
                                    {
                                        i++;  //leave the loop
                                    }
                                }
                            }
                            //if player chooses something other than H or S, asks question again
                            else
                            { }

                        } while ((hitStandChoice == "h" || hitStandChoice == "H") && i == 0);
                    }
                    //when round is over, reset scores
                    playerOne.SetCurrentScore(0);
                    compPlayer.SetCurrentScore(0);

                    Console.WriteLine("\n\nWould you like to play another round? (Y/N)");
                    switch (Console.ReadLine())
                    {
                        case "y":
                        case "Y":
                            break;
                        default:
                            strContinue = "N";
                            break;
                    }

                }//end gameplay loop

               



                //Console.WriteLine("Current end of main method.");

                Console.ReadKey();

            }//end while loop for bulk of game

        }//end main method

       

    }//end program class
}//namespace
