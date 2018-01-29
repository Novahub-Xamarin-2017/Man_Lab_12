using Android.App;
using Android.OS;

namespace Exercise_1
{
    [Activity(Label = "Exercise_1", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
        }
    }
}

