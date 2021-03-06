﻿using System;

namespace DiscordAndDragons.DnD
{
    public class RollController
    {
        private Random Random;

        public RollController()
        {
            // Make the random class
            Random = new Random();
        }

        public int RollDice(DiceType diceType)
        {

            var result = 0;
            switch (diceType)
            {
                case DiceType.D4:
                    result = RollDice(1, 5);
                    break;
                case DiceType.D6:
                    result = RollDice(1, 7);
                    break;
                case DiceType.D8:
                    result = RollDice(1, 9);
                    break;
                case DiceType.D10:
                    result = RollDice(1, 11);
                    break;
                case DiceType.D12:
                    result = RollDice(1, 13);
                    break;
                case DiceType.D20:
                    result = RollDice(1, 21);
                    break;
                case DiceType.D100:
                    result = RollDice(1, 101);
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// Function which picks the random number of the parameters which it has passed.
        /// </summary>
        /// <param name="minValue"></param> The minimum someone can roll 
        /// <param name="maxValue"></param> The maximum someone can roll -1
        /// <returns></returns> An int of a dice roll
        private int RollDice(int minValue, int maxValue)
        {
            // Pick the number
            int rolled = Random.Next(minValue, maxValue);

            // Return that number
            return rolled;
        }
    }
}
