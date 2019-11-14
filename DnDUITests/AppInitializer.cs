using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace DnDUITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android.InstalledApp("com.woochy.DnDApp").StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}