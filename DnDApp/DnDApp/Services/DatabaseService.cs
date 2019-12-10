using DnDEngine.Character;
using System;
using System.Collections.Generic;
using System.Text;
using Plugin.CloudFirestore;
using System.Threading.Tasks;
using System.Linq;
using DnDEngine.Utilities;
using DnDApp.Models;
using System.Collections.ObjectModel;
using Xamarin.Forms;

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

        public static async Task<List<CharacterTrait>> GetTraits(ICollectionReference traitsCollection)
        {
            var documents = await traitsCollection.GetDocumentsAsync();

            var traits = (from doc in documents.Documents
                          select new CharacterTrait((string)doc.Data["name"], (string)doc.Data["description"]));
            return traits.ToList();
        }

        public static async Task<CharacterRace> GetRace(IDocumentReference raceReference)
        {
            var document = await raceReference.GetDocumentAsync();
            var traits = await GetTraits(raceReference.GetCollection("traits"));

            return new CharacterRace
            {
                Name = (string)document.Data["name"],
                Description = (string)document.Data["description"],
                // TODO: add size, speed, and ability score modifiers.
                CharacterTraits = traits
            };
        }

        public static async Task<CharacterClass> GetClass(IDocumentReference classReference)
        {
            var document = await classReference.GetDocumentAsync();
            var traits = await GetTraits(classReference.GetCollection("traits"));

            return new CharacterClass
            {
                Name = (string)document.Data["name"],
                Description = (string)document.Data["description"],
                // TODO: add hit dice and proficiencies.
                CharacterTraits = traits
            };
        }

        public static async Task<CharacterBackground> GetBackground(IDocumentReference backgroundReference)
        {
            var document = await backgroundReference.GetDocumentAsync();
            var traits = await GetTraits(backgroundReference.GetCollection("traits"));

            return new CharacterBackground
            {
                Name = (string)document.Data["name"],
                Description = (string)document.Data["description"],
                CharacterTraits = traits
            };
        }

        public static async Task<PlayerCharacter> GetPlayerCharacter(User user, LightweightCharacterModel characterModel)
        {
            var characterRace = await GetRace(characterModel.RaceRef);
            var characterClass = await GetClass(characterModel.ClassRef);
            var characterBackground = await GetBackground(characterModel.BackgroundRef);

            var document = await CrossCloudFirestore.Current.Instance
                .GetDocument($"/users/{user.UID}/characters/{characterModel.UID}")
                .GetDocumentAsync();
            var character = document.ToObject<PlayerCharacter>();
            character.Race = characterRace;
            character.Class = characterClass;
            character.Background = characterBackground;

            return character;
        }

        public static async Task<Tileset> GetTileset(IDocumentReference tilesetRef)
        {
            var document = await tilesetRef.GetDocumentAsync();

            Tileset tileset = document.ToObject<Tileset>();
            return tileset;
        }

        public static void ObserveTilemaps(User user, ObservableCollection<Tilemap> collection)
        {
            CrossCloudFirestore.Current.Instance
                .GetCollection($"/users/{user.UID}/tilemaps")
                .AddSnapshotListener(async (snapshot, err) =>
                {
                    if (err != null)
                        throw err;
                    if (snapshot != null)
                    {
                        foreach(var change in snapshot.DocumentChanges)
                        {
                            // the collection must be updated on the UI thread, otherwise trying
                            // to change the CollectionView would throw an exception.
                            Device.BeginInvokeOnMainThread(async () =>
                            {
                                switch (change.Type)
                                {
                                    case DocumentChangeType.Added:
                                        collection.Insert(change.NewIndex, await DatabaseService.GetTilemap(change.Document.Reference));
                                        break;
                                    case DocumentChangeType.Modified:
                                        collection.RemoveAt(change.OldIndex);
                                        collection.Insert(change.NewIndex, await DatabaseService.GetTilemap(change.Document.Reference));
                                        break;
                                    case DocumentChangeType.Removed:
                                        collection.RemoveAt(change.OldIndex);
                                        break;
                                }
                            });
                        }
                    }
                });
        }

        public static async Task<Tilemap> GetTilemap(IDocumentReference tilemapRef)
        {
            var document = await tilemapRef.GetDocumentAsync();

            Tilemap tilemap = document.ToObject<Tilemap>();
            tilemap.Map = Tilemap.Reconstruct(tilemap.FlattenedMap, tilemap.Width, tilemap.Height);
            tilemap.Tileset = await GetTileset(tilemap.TilesetReference);
            tilemap.Reference = tilemapRef;
            await tilemap.Tileset.LoadImagesAsync();
            return tilemap;
        }

        public static async Task SaveTilemap(Tilemap tilemap)
        {
            tilemap.FlattenedMap = Tilemap.Flatten(tilemap.Map);
            await tilemap.Reference.UpdateDataAsync(tilemap);
        }

        public static async Task NewTilemap(User user)
        {
            Tilemap tilemap = Tilemap.New();
            await CrossCloudFirestore.Current.Instance
                .GetCollection($"/users/{user.UID}/tilemaps")
                .AddDocumentAsync(tilemap);
        }
    }
}
