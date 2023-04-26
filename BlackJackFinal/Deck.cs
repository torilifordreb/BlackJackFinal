using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BlackJackFinal
{
    public class Deck
    {
        //private ArrayList<Card> DeckInUse
        private List<Card> DeckInUse;
        private Player PlayerOne;
        private Computer ComputerPlayer;
        private Card FaceDownCard;


        public Deck(List<Card> DeckInUse, Player PlayerOne, Computer ComputerPlayer)
        {
            this.DeckInUse = DeckInUse;
            this.PlayerOne = PlayerOne;
            this.ComputerPlayer = ComputerPlayer;

        }



        //Using the Fisher-Yates Shuffle method
        public void Shuffle()
        {
            Random r = new Random();

            for (int i = 0; i <= 51; i++)
            {
                int y = r.Next(i + 1);
                Card temp = this.DeckInUse[i];
                this.DeckInUse[i] = this.DeckInUse[y];
                this.DeckInUse[y] = temp;
            }
        }

        //Deals Card and reveals details
        public string PlayerDealCard() 
        {
            Card cardToDeal = this.DeckInUse[0];

            //deal with aces
            if (cardToDeal.GetFace() == Face.Ace)
            {
                //if ace is drawn and the "11" value causes the score to exceed 21
                if (cardToDeal.GetValue() + PlayerOne.GetCurrentScore() > 21) 
                {
                    //change ace value to 1
                    cardToDeal.SetValue(1);
                }
            }

            //set players current score to card value
            PlayerOne.SetCurrentScore(PlayerOne.GetCurrentScore() + cardToDeal.GetValue());

            //remove drawn card from list
            DeckInUse.RemoveAt(0);

            //return string value of dealt card
            return cardToDeal.ToString();
        }

        public string computerDealCard()
        {
            Card cardToDeal = this.DeckInUse[0];

            //deal with aces
            if (cardToDeal.GetFace() == Face.Ace)
            {
                //if ace is drawn and the "11" value causes the score to exceed 21
                if (cardToDeal.GetValue() + ComputerPlayer.GetCurrentScore() > 21)
                {
                    //change ace value to 1
                    cardToDeal.SetValue(1);
                }
            }

            //set computers current score to card value
            ComputerPlayer.SetCurrentScore(ComputerPlayer.GetCurrentScore() + cardToDeal.GetValue());

            //remove drawn card from list
            DeckInUse.RemoveAt(0);

            //return string value of dealt card
            return cardToDeal.ToString();
        }



        //deals card and doesnt reveal details (dealer first card)
        public string DealCardFaceDown()
        {
            Card cardToDeal = this.DeckInUse[0];

            //deal with aces
            if (cardToDeal.GetFace() == Face.Ace)
            {
                //if ace is drawn and the "11" value causes the score to exceed 21
                if (cardToDeal.GetValue() + ComputerPlayer.GetCurrentScore() > 21)
                {
                    //change ace value to 1
                    cardToDeal.SetValue(1);
                }
            }
            else { }

            SetFaceDownCard(cardToDeal);

            //set computers current score to card value
            ComputerPlayer.SetFaceDownScore(cardToDeal.GetValue());

            //remove drawn card from list
            DeckInUse.RemoveAt(0);

            return "Face Down";
        }

        //method that checks players scores for blackjack or bust
        public bool ChkPlayerBlackJack()
        {
            bool checkBlackJack = PlayerOne.GetCurrentScore() == 21;

            if (checkBlackJack)
            {
                Console.WriteLine("\n\n***** !!!BLACKJACK!!! *****\t\t\t\tComp. Face Down Card: " + GetFaceDownCard());
                Console.WriteLine("\t\t\t\t\t\t\t" + PlayerOne.GetName() + "'s Score: " + PlayerOne.GetCurrentScore() + "\tComp.'s Score: " + ComputerPlayer.GetCurrentScore());
                //add bet and computer's equal bet to the players bank
                PlayerOne.SetInTheBank(PlayerOne.GetInTheBank() + (PlayerOne.GetPlayerBet() * 2));
            }

            return checkBlackJack;
        }

        public bool ChkPlayerBust()
        {
            bool checkBust = PlayerOne.GetCurrentScore() > 21;

            if (checkBust)
            {
                Console.WriteLine("\n\nBust.. Computer wins\t\t\t\t\tComp. Face Down Card: " + GetFaceDownCard());
                Console.WriteLine("\t\t\t\t\t\t\t" + PlayerOne.GetName() + "'s Score: " + PlayerOne.GetCurrentScore() + "\tComp.'s Score: " + ComputerPlayer.GetCurrentScore());
                //add player and computers bet to computers bank
                ComputerPlayer.SetInTheBank(ComputerPlayer.GetInTheBank() + (PlayerOne.GetPlayerBet() * 2));
            }

            return checkBust;
        }

        public bool ChkComputerBlackJack() 
        {
            bool checkBlackJack = ComputerPlayer.GetCurrentScore() + ComputerPlayer.GetFaceDownScore() == 21;

            if (checkBlackJack)
            {
                Console.WriteLine("\n\n***** Computer Wins! *****\t\t\t\tComp. Face Down Card: " + GetFaceDownCard());
                Console.WriteLine("\t\t\t\t\t\t\t" + PlayerOne.GetName() + "'s Score: " + PlayerOne.GetCurrentScore() + "\tComp.'s Score: " + ComputerPlayer.GetCurrentScore());
                //add bet and computer's equal bet to the computer's bank
                ComputerPlayer.SetInTheBank(ComputerPlayer.GetInTheBank() + (PlayerOne.GetPlayerBet() * 2));
            }

            return checkBlackJack;
        }

        public bool ChkComputerBust() 
        {
            bool checkBust = ComputerPlayer.GetCurrentScore()  + ComputerPlayer.GetFaceDownScore() > 21;

            if (checkBust)
            {
                Console.WriteLine("\n\nComputer busts.. You win!\t\t\t\tComp. Face Down Card: " + GetFaceDownCard());
                Console.WriteLine("\t\t\t\t\t\t\t" + PlayerOne.GetName() + "'s Score: " + PlayerOne.GetCurrentScore() + "\tComp.'s Score: " + ComputerPlayer.GetCurrentScore());
                //add player and computers bet to players total
                PlayerOne.SetInTheBank(PlayerOne.GetInTheBank() + (PlayerOne.GetPlayerBet() * 2));
            }

            return checkBust;
        }

        public string GetFaceDownCard()
        {
            ComputerPlayer.SetCurrentScore(ComputerPlayer.GetCurrentScore() + ComputerPlayer.GetFaceDownScore());
            return FaceDownCard.ToString();
        }

        public void SetFaceDownCard(Card FaceDownCard)
        {
            this.FaceDownCard = FaceDownCard;
        }

        public void printDeck()
        {
            foreach (Card c in DeckInUse)
            {
                Console.WriteLine(c.ToString());
            }
        }

    }
}
