﻿using System;
using Crawl.Models;


namespace Crawl.GameEngine
{
    public static class HelperEngine
    {
        /// <summary>
        /// Random should only be instantiated once
        /// Because each call to new Random will reset the seed value, and thus the numbers generated
        /// You can control the seed value for Random by passing a value to the constructor
        /// Do that if you want to be able able get the same sequence of Random over and over
        /// </summary>
        private static Random rnd = new Random();

        /// <summary>
        /// Method to Roll A Random Dice, a Set number of times
        /// </summary>
        /// <param name="rolls">The number of Rolls to Make</param>
        /// <param name="dice">The Dice to Roll</param>
        /// <returns></returns>
        public static int RollDice (int rolls, int dice)
        {

            var myReturn = 0;

            if (rolls < 1)
            {
                myReturn = 0;
            }

            if (dice < 1)
            {
                myReturn = 0;
            }

            if (Models.GameGlobals.ForceRollsToNotRandom)
            { 
                myReturn = rolls * Models.GameGlobals.ForcedRandomValue;
            }

            for (var i = 0; i < rolls; i++)
            {
                // Add one to the dice, because random is between.  So 1-10 is rnd.Next(1,11)
                myReturn += rnd.Next(1, dice + 1);
            }

            return myReturn;
        }
    }
}
