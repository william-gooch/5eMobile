using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public abstract class Character
    {
        public string Name { get; set; }

        public AbilityScores BaseAbilityScores { get; set; }

        public virtual int ArmorClass { get; }
        public virtual int MaximumHitPoints { get; }        

        public Character Clone()
        {
            return MemberwiseClone() as Character;
        }
    }
}
