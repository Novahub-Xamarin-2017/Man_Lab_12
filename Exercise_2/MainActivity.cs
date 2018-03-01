using System.IO;
using Android.App;
using Android.OS;
using Exercise_2.Models;
using Newtonsoft.Json;

namespace Exercise_2
{
    [Activity(Label = "Exercise_2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private AppData appData;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ReadData();
            StartActivity(appData.IsLoggedIn ? typeof(Chat) : typeof(Login));
        }

        private void ReadData()
        {
            var stream = Assets.Open("data.json");
            using (var streamReader = new StreamReader(stream))
            {
                var content = streamReader.ReadToEnd();
                appData = JsonConvert.DeserializeObject<AppData>(content);
            }
        }
    }
}

