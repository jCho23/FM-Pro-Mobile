using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace FCC
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
		public void Repl()
		{
			app.Repl();
		}

		[Test]
		public void UsernameNoPassword()
		{
			app.Tap(x => x.Marked("dialog_ValueField").Index(0));
			app.Screenshot("Let's Start by Tapping on the Email Text Field");
			app.EnterText("FmPro@mobile.com");
			app.Screenshot("Then we entered out Email, 'FmPro@mobile.com'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			app.Tap("dialog_Button");
			app.Screenshot("Then we Tapped on the 'Sign In'");
		}

		[Test]
		public void PasswordNoUsername()
		{
			app.Tap(x => x.Marked("dialog_ValueField").Index(1));
			app.Screenshot("Let's Start by Tapping on the Password Text Field");
			app.EnterText("Microsoft");
			app.Screenshot("Then we entered out Email, 'Microsoft'");
			app.DismissKeyboard();
			app.Screenshot("Dismissed Keyboard");
			app.Tap("dialog_Button");
			app.Screenshot("Then we Tapped on the 'Sign In'");
		}

	}
}
