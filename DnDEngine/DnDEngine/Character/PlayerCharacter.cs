using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public class PlayerCharacter : Character
    {
        public PlayerCharacter(string name, AbilityScores baseAbilityScores, int armorClass, int maximumHitPoints) : base(name, baseAbilityScores, armorClass, maximumHitPoints)
        {

        }
    }
}
