using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class EnemyAI
    {
        private const int UPPER_BOUND = 100;            //random number generator

        private int DifficultyNumber;
        private Random RandomNumber;

        public EnemyAI(int ai_difficultyNumber)  //Assigned difficulty
        {
            DifficultyNumber = ai_difficultyNumber;
            RandomNumber = new Random();
        }

        public bool IsAttacking()
        {
            return RandomNumber.Next(UPPER_BOUND) < DifficultyNumber;
        }

        public bool IsMoving()
        {
            return RandomNumber.Next(UPPER_BOUND) < DifficultyNumber;
        }
    }
}
