using Android.App;
using Android.OS;

namespace SummerTestApp.Activity
{
    [Activity(Label = "SummerTestApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : Android.App.Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

        }
    }
}

