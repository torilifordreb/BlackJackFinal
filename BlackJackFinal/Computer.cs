using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackFinal
{
    public class Computer
    {
        private double InTheBank = 1_000_000.00;     //dealer starts with one million
        private int CurrentScore = 0;
        private int FaceDownScore = 0;

        public Computer()
        { 
            
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

        public int GetFaceDownScore()
        {
            return FaceDownScore;
        }

        public void SetFaceDownScore(int FaceDownScore)
        {
            this.FaceDownScore = FaceDownScore;
        }

    }
}
