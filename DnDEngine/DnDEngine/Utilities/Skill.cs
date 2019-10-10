using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Utilities
{
    /// <summary>
    /// Contains the skills present in the game.
    /// </summary>
    [Flags]
    public enum Skill
    {
        None = 0,
        Acrobatics,
        Animal_Handling,
        Arcana,
        Athletics,
        Deception,
        History,
        Insight,
        Intimidation,
        Investigation,
        Medicine,
        Nature,
        Perception,
        Performance,
        Persuasion,
        Religion,
        Sleight_Of_Hand,
        Stealth,
        Survival
    }
}
