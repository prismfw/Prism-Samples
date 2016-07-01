using Android.App;
using Android.OS;

namespace SampleSuite.Android
{
    [Activity(Label = "Sample Suite", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Prism.Android.AndroidInitializer.Initialize(new App(), this);
        }
    }
}

