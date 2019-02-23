using DnDEngine.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character.CharacterRace
{
    public class CharacterRace
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Size Size { get; private set; }
        public int Speed { get; private set; }

        public AbilityScores AbilityScoresMod { get; private set; }
    }
}
