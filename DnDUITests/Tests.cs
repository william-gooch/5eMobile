using System;
using System.Diagnostics;
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
        public void UserCanLogIn()
        {
            app.Tap(c => c.Marked("Sign In"));
            app.Tap(c => c.Marked("E-mail"));
            app.EnterText("william.gooch.wg@gmail.com");
            app.Tap(c => c.Marked("Password"));
            app.EnterText("password");

            app.Tap(c => c.Marked("Log In"));
            app.WaitForElement(c => c.Marked("Characters"));
        }

        [Test]
        public void UserCanLogOut()
        {
            UserCanLogIn();

            app.Tap(c => c.Marked("Log Out"));
            app.WaitForElement(c => c.Marked("Sign In"));
        }

        [Test]
        public void MainMenuHasCorrectButtons()
        {
            Assert.IsNotEmpty(app.Query(c => c.Marked("Characters")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Maps")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Games")));
            Assert.IsNotEmpty(app.Query(c => c.Marked("Sign In")));
        }

        [Test]
        public void UserCanSelectCharacter()
        {
            UserCanLogIn();

            app.Tap(c => c.Marked("Characters"));
            app.WaitForElement(c => c.Marked("CharacterCell"));

            Assert.IsEmpty(app.Query(c => c.Marked("CharacterCell").Child().Text("")));
            app.Tap(c => c.Marked("CharacterCell"));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            app.WaitForNoElement(c => c.Marked("CharacterCell"));
            sw.Stop();
            Console.WriteLine($"Request to the database took {sw.Elapsed.TotalSeconds}secs to execute");
        }

        [Test]
        public void CharacterDisplaysAbilityScores()
        {
            UserCanSelectCharacter();
            Assert.IsNotEmpty(app.Query(c => c.Marked("AbilityScoreView")));
            Assert.IsEmpty(app.Query(
                c => c.Marked("AbilityScoreView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysSkills()
        {
            UserCanSelectCharacter();
            Assert.IsNotEmpty(app.Query(c => c.All().Marked("SkillView")));
            Assert.IsEmpty(app.Query(
                c => c.All().Marked("SkillView")
                    .Child().Text("")
            ));
        }

        [Test]
        public void CharacterDisplaysTraits()
        {
            UserCanSelectCharacter();
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
            UserCanSelectCharacter();

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
