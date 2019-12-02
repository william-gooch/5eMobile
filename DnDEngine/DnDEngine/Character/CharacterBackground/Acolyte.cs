using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public partial class CharacterBackground
    {
        public static CharacterBackground Acolyte() => _acolyte.Clone();
        private static CharacterBackground _acolyte = new CharacterBackground
        {
            Name = "Acolyte",
            Description = "You have spent your life in the service of a temple to a specific god or pantheon of gods.",

            CharacterTraits = new List<CharacterTrait> {
                new CharacterTrait("Shelter of the Faithful", "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity.")
            }
        };
    }
}
