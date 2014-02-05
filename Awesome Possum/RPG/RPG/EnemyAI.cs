using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class EnemyAI
    {
        private const int NUMBER_OF_DIFFICULTIES = 3;  // CHANGE THIS
        private const int LOWER_BOUND = 1;             //random number generator & difficulty level
        private const int UPPER_BOUND = 10;            //random number generator

        private int difficultyNumber;
        private Random randomNumber;
        private int boundPartitionSize;

        public EnemyAI(int ai_difficultyNumber)  //Assigned difficulty
        {
            randomNumber = new Random();
            boundPartitionSize = UPPER_BOUND / NUMBER_OF_DIFFICULTIES;

            if (ai_difficultyNumber < LOWER_BOUND)
            {
                difficultyNumber = LOWER_BOUND;
            }
            else if (ai_difficultyNumber > NUMBER_OF_DIFFICULTIES)
            {
                difficultyNumber = NUMBER_OF_DIFFICULTIES;
            }
            else
            {
                difficultyNumber = ai_difficultyNumber;
            }
        }

        public EnemyAI()  //Random difficulty
        {
            int randomNumberUpperBound = NUMBER_OF_DIFFICULTIES + 1;
            difficultyNumber = randomNumber.Next(LOWER_BOUND, randomNumberUpperBound);
        }

        public bool IsAttacking()
        {
            int randomNumberUpperBound = UPPER_BOUND + 1;
            int r_number = randomNumber.Next(LOWER_BOUND, randomNumberUpperBound);
            int attackUpperBound = boundPartitionSize * difficultyNumber;

            if (r_number <= attackUpperBound)
            {
                return true;
            }
            return false;
        }

        public bool IsMoving()
        {
            int randomNumberUpperBound = UPPER_BOUND + 1;
            int r_number = randomNumber.Next(LOWER_BOUND, randomNumberUpperBound);
            int attackUpperBound = boundPartitionSize * difficultyNumber;

            if (r_number <= attackUpperBound)
            {
                return true;
            }
            return false;
        }
    }
}
