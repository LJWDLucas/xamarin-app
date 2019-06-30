using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace StudybuddiesTestApp
{
    [TestFixture(Platform.Android)]
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
        public void CanSuccessfullyLoginToApp()
        {
            app.EnterText("UsernameEntry", "danny@lucas.nl");
            app.EnterText("PasswordEntry", "123123123");
            app.Tap("LoginButton");
            app.WaitForElement("Create");
            app.Tap(a => a.Marked("Create"));
            app.WaitForElement("Create an assignment");
            app.EnterText("EntryId", "This is an automated test assignment");
            app.EnterText("EditorId", "This is an automated test assignment editor text");
            app.Tap(a => a.Marked("None"));
        }
    }
}
