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
        static void PlayerCharacterInfo(PlayerCharacter character)
        {
            Console.WriteLine($"--- {character.Name.ToUpper()} ---");
            Console.WriteLine($"{character.Race.Name} {character.Class.Name}, {character.Background.Name}");
            Console.WriteLine($"HP: {character.MaximumHitPoints}");
            Console.WriteLine($"Armor Class: {character.ArmorClass}");
            Console.WriteLine($"Hit Dice: {character.Class.HitDice}");

            Console.WriteLine($"STR: {character.BaseAbilityScores.Strength} ({character.BaseAbilityScores.StrengthMod})");
            Console.WriteLine($"DEX: {character.BaseAbilityScores.Dexterity} ({character.BaseAbilityScores.DexterityMod})");
            Console.WriteLine($"CON: {character.BaseAbilityScores.Constitution} ({character.BaseAbilityScores.ConstitutionMod})");
            Console.WriteLine($"INT: {character.BaseAbilityScores.Intelligence} ({character.BaseAbilityScores.IntelligenceMod})");
            Console.WriteLine($"WIS: {character.BaseAbilityScores.Wisdom} ({character.BaseAbilityScores.WisdomMod})");
            Console.WriteLine($"CHA: {character.BaseAbilityScores.Charisma} ({character.BaseAbilityScores.CharismaMod})");
            Console.WriteLine("\nTRAITS:\n");
            character.CharacterTraits.ForEach((trait) =>
            {
                Console.WriteLine(trait.Name.ToUpper() + ":\n" + trait.Description);
            });
        }

        static void CharacterInfo(Character character)
        {
            Console.WriteLine($"--- {character.Name.ToUpper()} ---");
            Console.WriteLine($"HP: {character.MaximumHitPoints}");
            Console.WriteLine($"Armor Class: {character.ArmorClass}");

            Console.WriteLine($"STR: {character.BaseAbilityScores.Strength} ({character.BaseAbilityScores.StrengthMod})");
            Console.WriteLine($"DEX: {character.BaseAbilityScores.Dexterity} ({character.BaseAbilityScores.DexterityMod})");
            Console.WriteLine($"CON: {character.BaseAbilityScores.Constitution} ({character.BaseAbilityScores.ConstitutionMod})");
            Console.WriteLine($"INT: {character.BaseAbilityScores.Intelligence} ({character.BaseAbilityScores.IntelligenceMod})");
            Console.WriteLine($"WIS: {character.BaseAbilityScores.Wisdom} ({character.BaseAbilityScores.WisdomMod})");
            Console.WriteLine($"CHA: {character.BaseAbilityScores.Charisma} ({character.BaseAbilityScores.CharismaMod})");
            Console.WriteLine("\nTRAITS:\n");
            character.CharacterTraits.ForEach((trait) =>
            {
                Console.WriteLine(trait.Name.ToUpper() + ":\n" + trait.Description);
            });
        }

        static void Main(string[] args)
        {
            var myPlayerCharacter = new PlayerCharacter("Lukan Volgen", new AbilityScores(20, 9, 16, 9, 13, 12),
                new CharacterRace.Dragonborn(),
                new CharacterClass.Barbarian(),
                new CharacterBackground.Acolyte());
            PlayerCharacterInfo(myPlayerCharacter);

            Console.WriteLine("\n\n");

            var myEnemy = CharacterPresets.goblin.Clone();
            CharacterInfo(myEnemy);

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
