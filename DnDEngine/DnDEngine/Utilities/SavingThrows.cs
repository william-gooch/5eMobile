using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    /// <summary>
    /// Contains all of the different kinds of saving throws that can happen.
    /// This is used to implement saving throw proficiencies.
    /// </summary>
    [Flags]
    public enum SavingThrows
    {
        Strength = 1 << 0,
        Dexterity = 1 << 1,
        Constitution = 1 << 2,
        Intelligence = 1 << 3,
        Wisdom = 1 << 4,
        Charisma = 1 << 5
    }
}
