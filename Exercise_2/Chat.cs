using Android.App;
using Android.OS;

namespace Exercise_2
{
    [Activity(Label = "Chat")]
    public class Chat : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChatLayout);
            // Create your application here
        }
    }
}