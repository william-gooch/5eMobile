using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DnDEngine;
using DnDEngine.Character;
using DnDEngine.Utilities;

namespace DnDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var myPlayerCharacter = new PlayerCharacter("Lukan Volgen", new AbilityScores(20, 9, 16, 9, 13, 12),
                new DnDEngine.Character.CharacterRace.CharacterRaceDragonborn(),
                new DnDEngine.Character.CharacterClass.CharacterClassBarbarian(),
                new DnDEngine.Character.CharacterBackground.CharacterBackgroundAcolyte());
            Console.WriteLine($"--- {myPlayerCharacter.Name.ToUpper()} ---");
            Console.WriteLine($"{myPlayerCharacter.Race.Name} {myPlayerCharacter.Class.Name}, {myPlayerCharacter.Background.Name}");
            Console.WriteLine($"HP: {myPlayerCharacter.MaximumHitPoints}");
            Console.WriteLine($"Armor Class: {myPlayerCharacter.ArmorClass}");
            Console.WriteLine($"STR: {myPlayerCharacter.BaseAbilityScores.Strength} ({myPlayerCharacter.BaseAbilityScores.StrengthMod})");
            Console.WriteLine($"DEX: {myPlayerCharacter.BaseAbilityScores.Dexterity} ({myPlayerCharacter.BaseAbilityScores.DexterityMod})");
            Console.WriteLine($"CON: {myPlayerCharacter.BaseAbilityScores.Constitution} ({myPlayerCharacter.BaseAbilityScores.ConstitutionMod})");
            Console.WriteLine($"INT: {myPlayerCharacter.BaseAbilityScores.Intelligence} ({myPlayerCharacter.BaseAbilityScores.IntelligenceMod})");
            Console.WriteLine($"WIS: {myPlayerCharacter.BaseAbilityScores.Wisdom} ({myPlayerCharacter.BaseAbilityScores.WisdomMod})");
            Console.WriteLine($"CHA: {myPlayerCharacter.BaseAbilityScores.Charisma} ({myPlayerCharacter.BaseAbilityScores.CharismaMod})");
            Console.ReadKey();
        }
    }
}
