using Android.Content;
using Android.Util;

namespace Exercise_2
{
    public class MessageBroadcastReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Log.Info("fromUser", intent.GetStringExtra("from"));
            Log.Info("Message", intent.GetStringExtra("message"));
        }
    }
}