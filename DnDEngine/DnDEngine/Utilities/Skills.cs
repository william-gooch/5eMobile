using System;
using System.Collections.Generic;
using System.Linq;
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
        Acrobatics      = 1 << 0,
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
        Survival        = 1 << 17
    }

    public static class SkillTypes
    {
        public static Skills Strength = Skills.Athletics;
        public static Skills Dexterity = Skills.Acrobatics | Skills.Sleight_Of_Hand | Skills.Stealth;
        public static Skills Constitution = 0;
        public static Skills Intelligence = Skills.Arcana | Skills.History | Skills.Investigation | Skills.Nature | Skills.Religion;
        public static Skills Wisdom = Skills.Animal_Handling | Skills.Insight | Skills.Medicine | Skills.Perception | Skills.Survival;
        public static Skills Charisma = Skills.Deception | Skills.Intimidation | Skills.Performance | Skills.Persuasion;
    }

    public static class EnumExtensions
    {
        public static Dictionary<string, bool> GetFlags(this Enum flags)
        {
            return (from Enum flag
                    in Enum.GetValues(flags.GetType())
                    select new {
                        Key = Enum.GetName(flags.GetType(), flag),
                        Value = flags.HasFlag(flag)
                    }).ToDictionary(t => t.Key, t => t.Value);
        }
    }
}
