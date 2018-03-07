using Android.App;
using Android.Util;
using Firebase.Iid;

namespace Exercise_2
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseInstanceIdService : FirebaseInstanceIdService
    {
        private const string Tag = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(Tag, "Refreshed token: " + refreshedToken);
        }
    }
}