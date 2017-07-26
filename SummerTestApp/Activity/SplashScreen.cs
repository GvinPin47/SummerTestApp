using Android.App;
using Android.OS;
using Android.Support.V7.App;

namespace SummerTestApp.Activity
{
    [Activity(Label = "SummerTestApp", MainLauncher = true,Theme="@style/NoSmoking.Theme", Icon = "@drawable/icon")]
    public class SplashScreen : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            SetContentView (Resource.Layout.splash_screen);
            StartActivity(typeof(EditData));
        }
    }
}

