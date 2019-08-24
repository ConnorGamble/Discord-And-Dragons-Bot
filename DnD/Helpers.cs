using System;

namespace MyDick.DnD
{
    public static class Helpers
    {
        /// <summary>
        /// Function which picks the random number of the parameters which it has passed.
        /// </summary>
        /// <param name="minValue"></param> The minimum someone can roll 
        /// <param name="maxValue"></param> The maximum someone can roll -1
        /// <returns></returns> An int of a dice roll
        public static int RollDice(int minValue, int maxValue)
        {
            // Make the random class
            Random rnd = new Random();

            // Pick the number
            int rolled = rnd.Next(minValue, maxValue);

            // Return that number
            return rolled;
        }
    }
}
