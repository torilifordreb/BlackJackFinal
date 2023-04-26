using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackFinal
{
    public class Player
    {
		private string Name;
		private double InTheBank;
		private int CurrentScore;
		private double PlayerBet = 0.0;

		public Player()
		{
			SetName("");
			SetInTheBank(0.00);
			SetCurrentScore(0);
			SetPlayerBet(0.0);
		}

		public Player(string name, double inTheBank, double PlayerBet, int currentScore = 0)
		{
			SetName(name);
			SetInTheBank(inTheBank);
			SetCurrentScore(currentScore);
			SetPlayerBet(PlayerBet);
		}


		//getters and setters
		public string GetName()
		{
			return Name;
		}
		public void SetName(string name)
		{
			this.Name = name;
		}

		public double GetInTheBank()
		{
			return InTheBank;
		}

		public void SetInTheBank(double inTheBank)
		{
			this.InTheBank = inTheBank;
		}

		public int GetCurrentScore()
		{
			return CurrentScore;
		}

		public void SetCurrentScore(int currentScore)
		{
			this.CurrentScore = currentScore;
		}

		public double GetPlayerBet()
		{
			return PlayerBet;
		}

		public void SetPlayerBet(double PlayerBet)
		{
			this.PlayerBet = PlayerBet;
		}

		
	}
}
