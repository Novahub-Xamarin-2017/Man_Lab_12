using Android.App;
using Firebase.Messaging;

namespace Exercise_1
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            var builder = new Notification.Builder(this)
                .SetContentTitle(message.From)
                .SetContentText(message.GetNotification().Body)
                .SetSmallIcon(Resource.Drawable.football);
            var notification = builder.Build();
            notification.Defaults |= NotificationDefaults.Vibrate;
            var notificationManager =
                GetSystemService(NotificationService) as NotificationManager;
            const int notificationId = 0;
            notificationManager?.Notify(notificationId, notification);
        }
    }
}