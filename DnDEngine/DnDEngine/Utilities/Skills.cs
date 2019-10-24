using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    /// <summary>
    /// Contains the skills present in the game.
    /// Each is a flag (i.e. only one binary digit in varying places) which means
    /// that there can be multiple skills in just one representation.
    /// </summary>
    /// <example>Skills.Acrobatics | Skills.Arcana will include both skills.</example>
    [Flags]
    public enum Skills
    {
        None = 0,
        Acrobatics = 1 << 0,
        Animal_Handling = 1 << 1,
        Arcana          = 1 << 2,
        Athletics       = 1 << 3,
        Deception       = 1 << 4,
        History         = 1 << 5,
        Insight         = 1 << 6,
        Intimidation    = 1 << 7,
        Investigation   = 1 << 8,
        Medicine        = 1 << 9,
        Nature          = 1 << 10,
        Perception      = 1 << 11,
        Performance     = 1 << 12,
        Persuasion      = 1 << 13,
        Religion        = 1 << 14,
        Sleight_Of_Hand = 1 << 15,
        Stealth         = 1 << 16,
        Survival        = 1 << 17,

        Strength = Athletics,
        Dexterity = Acrobatics | Sleight_Of_Hand | Stealth,
        Constitution = None,
        Intelligence = Arcana | History | Nature | Religion,
        Wisdom = Animal_Handling | Insight | Medicine | Perception | Survival,
        Charisma = Deception | Intimidation | Performance | Persuasion
    }
}
