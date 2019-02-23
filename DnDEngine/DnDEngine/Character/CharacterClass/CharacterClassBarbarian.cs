using System;
using System.Collections.Generic;
using System.Text;
using DnDEngine.Utilities;

namespace DnDEngine.Character.CharacterClass
{
    public class CharacterClassBarbarian : CharacterClass
    {
        public override string Name { get; } = "Barbarian";
        public override string Description { get; } = "Barbarians come alive in the chaos of combat.They can enter a berserk state where rage takes over, giving them superhuman strength and resilience.";

        public override Roll HitDice { get; } = Roll.D(12);

        public override Skills SkillProficiencies => throw new NotImplementedException();
        public override SavingThrows SavingThrowProficiencies { get; } = SavingThrows.Strength | SavingThrows.Constitution;
    }
}
