using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character
{
    public partial class CharacterClass
    {
        public static CharacterClass Barbarian() => _barbarian.Clone();
        private static CharacterClass _barbarian = new CharacterClass
        {
            Name = "Barbarian",
            Description = "Barbarians come alive in the chaos of combat.They can enter a berserk state where rage takes over, giving them superhuman strength and resilience.",

            HitDice = Roll.D(12),
            SavingThrowProficiencies = SavingThrows.Strength | SavingThrows.Constitution,

            CharacterTraits = new List<CharacterTrait> {
                new CharacterTrait("Unarmored Defense", "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier. You can use a shield and still gain this benefit.")
            }
        };
    }
}
