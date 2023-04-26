using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackFinal
{
	//enum for suit
	public enum Suit
	{
		Heart,
		Diamond,
		Spade,
		Club
	}

	//enum for face
	public enum Face
	{
		Ace,
		Two,
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King
	}

	public class Card
    {

		private Suit cSuit;
		private Face cFace;
		private int cValue;

		public Card(Suit cSuit, Face cFace)
		{
			SetSuit(cSuit);
			SetFace(cFace);
		}


		//getters and setters
		//suit getter
		public string GetSuit()
		{
			return cSuit.ToString();
		}

		//suit setter
		public void SetSuit(Suit cSuit)
		{
			this.cSuit = cSuit;
		}
		//faceValue getter
		public Face GetFace()
		{
			return cFace;
		}
		//setter for faceValue
		public void SetFace(Face cFace)
		{
			this.cFace = cFace;
		}
		//returns the cards value based on enum
		public int GetValue() 
		{
			switch ((int)this.cFace)
			{
				case 0:     //ace
					this.SetValue(11);
					break;
				case 1:     //two
					this.SetValue(2);
					break;
				case 2:     //three
					this.SetValue(3);
					break;
				case 3:     //four
					this.SetValue(4);
					break;
				case 4:     //five
					this.SetValue(5);
					break;
				case 5:     //six
					this.SetValue(6);
					break;
				case 6:     //seven
					this.SetValue(7);
					break;
				case 7:     //eight
					this.SetValue(8);
					break;
				case 8:     //nine
					this.SetValue(9);
					break;
				case 9:     //ten-K
				case 10:
				case 11:
				case 12:
					this.SetValue(10);
					break;
			}//end switch

			return cValue;
		}
		//sets the cards value at a different int (used for ace card)
		public void SetValue(int cValue) {
			this.cValue = cValue;
		}

        //toString override method
        public override string ToString()
        {
			return this.cFace.ToString() + " of " + this.cSuit.ToString() + "\t";
        }
    }
}
