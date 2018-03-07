using Android.App;
using Android.OS;
using Android.Util;
using Exercise_2.Services;

namespace Exercise_2
{
    [Activity(Label = "Exercise_2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var dataManager = DataManager.GetInstance;
            Log.Info("Token", dataManager.AppData.FirebaseToken);
            StartActivity(dataManager.AppData.LoggedStatus ? typeof(Chat) : typeof(Login));
        }
    }
}

