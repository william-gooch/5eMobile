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

        /// <summary>
        /// This method is a public constructor that only takes the number of sides.
        /// This is called D to mimic the syntax that most rolls in DnD take in the books.
        /// E.g. 2d20+2 rolls 2 20 sided dice and adds two.
        /// </summary>
        /// <example>D(20)</example>
        /// <returns>The Roll instance created.</returns>
        public static Roll D(int numberOfSides)
        {
            return new Roll(numberOfSides, 1, 0);
        }

        /// <summary>
        /// This method overrides the + operator in order to add a modifier to the roll.
        /// E.g. 1d10+5, the +5 adds 5 to the roll.
        /// </summary>
        /// <param name="roll">The roll to add the modifier to.</param>
        /// <param name="modifier">The modifer to add.</param>
        /// <returns>The result of the operation.</returns>
        public static Roll operator +(Roll roll, int modifier)
        {
            return new Roll(roll.numberOfSides, roll.numberOfDice, roll.modifier + modifier);
        }

        /// <summary>
        /// This method overrides the - operator in order to take away a modifier from the roll.
        /// E.g. 1d10-5, the -5 subtracts 5 from the roll.
        /// </summary>
        /// <param name="roll">The roll to subtract the modifier from.</param>
        /// <param name="modifier">The modifier to subtract.</param>
        /// <returns>The result of the operation.</returns>
        public static Roll operator -(Roll roll, int modifier)
        {
            return new Roll(roll.numberOfSides, roll.numberOfDice, roll.modifier - modifier);
        }

        /// <summary>
        /// This method overrides the * operator in order to multiply the number of dice rolled.
        /// E.g. 4d12+2, the 4 means that you roll 4 dice.
        /// This can be combined with the + and - operators to generate a full dice roll.
        /// </summary>
        /// <param name="roll">The roll to multiply.</param>
        /// <param name="numberOfDice">The number of dice to roll.</param>
        /// <returns>The result of the operation.</returns>
        public static Roll operator *(Roll roll, int numberOfDice)
        {
            return new Roll(roll.numberOfSides, roll.numberOfDice * numberOfDice, roll.modifier);
        }
    }
}
