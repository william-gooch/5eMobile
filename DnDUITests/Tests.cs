using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DnDUITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void MainMenuHasCorrectButtons()
        {
            Assert.IsNotEmpty(app.Query(c => c.Marked("Characters")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Maps")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Games")));
        }

        [Test]
        public void CharacterDisplaysAbilityScores()
        {
            app.Tap(c => c.Marked("Characters"));
            Assert.IsEmpty(app.Query(
                c => c.Marked("AbilityScoreView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysSkills()
        {
            app.Tap(c => c.Marked("Characters"));
            Assert.IsEmpty(app.Query(
                c => c.Marked("SkillView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysTraits()
        {
            app.Tap(c => c.Marked("Characters"));
            app.Tap(c => c.Marked("Traits"));

            Assert.IsNotEmpty(app.Query(
                c => c.All().Marked("TraitsView")
            ));

            Assert.IsEmpty(app.Query(
                c => c.All().Marked("TraitsView")
                .Child().Text("")
            ));
        }

        [Test]
        public void CharacterRollsDice()
        {
            app.Tap(c => c.Marked("Characters"));
            // should tap the first ability score view, i.e. strength
            app.Tap(c => c.Marked("AbilityScoreView"));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Result")));
            Assert.IsEmpty(app.Query(c => c.Marked("Result").Text("")));
            Assert.IsEmpty(app.Query(c => c.Marked("Description").Text("")));

            // this tries to minimize the chance that the test fails by chance
            // if the value is coincidentally the same both times it will try again.
            for (int tries = 5; tries >= 0; tries--) {
                string previousValue = app.Query("Result").First().Text;
                app.Tap(c => c.Marked("Re-roll"));
                string currentValue = app.Query("Result").First().Text;
                if (previousValue != currentValue)
                    Assert.Pass();
            }
            Assert.Fail("Result does not change after 5 tries");
        }
    }
}
