using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character
{
    public abstract partial class CharacterClass
    {
        public class Barbarian : CharacterClass
        {
            public override string Name { get; } = "Barbarian";
            public override string Description { get; } = "Barbarians come alive in the chaos of combat.They can enter a berserk state where rage takes over, giving them superhuman strength and resilience.";

            public override Roll HitDice { get; } = Roll.D(12);

            public override Dictionary<Skill, int> SkillProficiencies => throw new NotImplementedException();
            public override SavingThrows SavingThrowProficiencies { get; } = SavingThrows.Strength | SavingThrows.Constitution;

            public override List<CharacterTrait> CharacterTraits => new List<CharacterTrait> {
                new CharacterTrait("Unarmored Defense", "While you are not wearing any armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier. You can use a shield and still gain this benefit.")
            };
        }
    }
}
