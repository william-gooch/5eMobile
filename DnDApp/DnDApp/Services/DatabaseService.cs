using DnDEngine.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.CloudFirestore;
using System.Threading.Tasks;
using System.Linq;
using DnDEngine.Utilities;
using DnDApp.Models;

namespace DnDApp.Services
{
    static class DatabaseService
    {
        public static async Task<IEnumerable<LightweightCharacterModel>> GetCharacters(User user)
        {
            var documents = await CrossCloudFirestore.Current.Instance
                .GetCollection("users")
                .GetDocument(user.UID)
                .GetCollection("characters")
                .GetDocumentsAsync();

            var characters = documents.ToObjects<LightweightCharacterModel>();
            return characters;
        }

        public static async Task<PlayerCharacter> GetPlayerCharacter(User user, LightweightCharacterModel characterModel)
        {
            // TODO: Actually implement this method properly
            var character = new PlayerCharacter(characterModel.Name,
                new AbilityScores(0,0,0,0,0,0),
                new CharacterRace.Dragonborn(),
                new CharacterClass.Barbarian(),
                new CharacterBackground.Acolyte());

            return character;
        }
    }
}
