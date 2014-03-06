using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class EnemyAI
    {
        enum States
        {
            IDLE,
            WALKING
        }

        private const int UPPER_BOUND = 1000;            //random number generator

        private int DifficultyNumber;
        private Random RandomNumber;

        private int MinWalkTime;
        private int MaxWalkTime;

        private int MinWaitTime;
        private int MaxWaitTime;

        private int WaitTime;
        private States State;

        public EnemyAI(int ai_difficultyNumber)  //Assigned difficulty
        {
            DifficultyNumber = ai_difficultyNumber;
            RandomNumber = new Random();

            MaxWalkTime = ai_difficultyNumber * 40 + 1000;
            MinWalkTime = ai_difficultyNumber * 27 + 250;

            MaxWaitTime = ai_difficultyNumber * -25 + 3000;
            MinWaitTime = ai_difficultyNumber * -10 + 1000;
        }

        public bool IsAttacking()
        {
            return false;
            //return RandomNumber.Next(UPPER_BOUND) < DifficultyNumber;
        }

        public bool IsMoving()
        {
            if (WaitTime < Environment.TickCount)
            {
                if (State == States.IDLE)
                {
                    State = States.WALKING;
                    WaitTime = Environment.TickCount + RandomNumber.Next(MinWalkTime, MaxWalkTime);
                }
                else
                {
                    State = States.IDLE;
                    WaitTime = Environment.TickCount + RandomNumber.Next(MinWaitTime, MaxWaitTime);
                }
            }

            return State == States.WALKING;
        }
    }
}
