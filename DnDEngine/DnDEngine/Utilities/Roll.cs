using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    /// <summary>
    /// The Roll class will hold all utilities for creating dice rolls.
    /// </summary>
    class Roll
    {
        private int numberOfSides;
        private int numberOfDice;
        private int modifier;

        public int value;

        /// <summary>
        /// This private constructor is used within the class to make a new Roll instance.
        /// </summary>
        /// <param name="numberOfSides">The number of sides each dice has.</param>
        /// <param name="numberOfDice">The number of dice to roll.</param>
        /// <param name="modifier">A modifier to add after the roll.</param>
        private Roll(int numberOfSides, int numberOfDice, int modifier)
        {
            this.numberOfSides = numberOfSides;
            this.numberOfDice = numberOfDice;
            this.modifier = modifier;
        }
    }
}
