using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;

namespace Exercise_2
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string Tag = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(Tag, "From: " + message.From);
            Log.Debug(Tag, "Notification Message Body: " + message.GetNotification().Body);

            var intent = new Intent(this,typeof(Chat));
            intent.PutExtra("message", message.GetNotification().Body);
            intent.PutExtra("from", message.GetNotification().Title);
            StartActivity(intent);
        }
    }
}