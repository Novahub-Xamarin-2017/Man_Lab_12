using Android.App;
using Android.Util;
using Firebase.Iid;

namespace Exercise_1
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIdService : FirebaseInstanceIdService
    {
        private const string Tag = "MyFirebaseIIDService";
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(Tag, "Refreshed token: " + refreshedToken);
        }
    }
}