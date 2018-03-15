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
        private const string Tag = "MyFirebaseMsgService";
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(Tag, "From: " + message.From);
            Log.Debug(Tag, "Notification Message Body: " + message.GetNotification().Body);

            var intent = new Intent(this,typeof(Chat));
            intent.PutExtra("message", message.GetNotification().Body);
            intent.PutExtra("from", message.GetNotification().Title);
            StartActivity(intent);

            var builder = new Notification.Builder(this)
                .SetContentTitle(message.From)
                .SetContentText(message.GetNotification().Body)
                .SetSmallIcon(Resource.Drawable.bug);
            var notification = builder.Build();
            notification.Defaults |= NotificationDefaults.Vibrate;
            var notificationManager =
                GetSystemService(NotificationService) as NotificationManager;
            const int notificationId = 0;
            notificationManager?.Notify(notificationId, notification);
        }
    }
}