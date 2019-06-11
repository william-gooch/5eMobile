using System;
using System.Collections.Generic;
using System.Text;

namespace DnDEngine.Character
{
    public abstract partial class CharacterBackground
    {
        public class Acolyte : CharacterBackground
        {
            public override string Name { get; } = "Acolyte";
            public override string Description { get; } = "You have spent your life in the service of a temple to a specific god or pantheon of gods.";

            public override List<CharacterTrait> CharacterTraits => new List<CharacterTrait> {
                new CharacterTrait("Shelter of the Faithful", "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity.")
            };
        }
    }
}
