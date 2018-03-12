using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views.InputMethods;
using Android.Widget;
using Exercise_2.Adapter;
using Exercise_2.Services;

namespace Exercise_2
{
    [Activity(Label = "Chat", LaunchMode = LaunchMode.SingleInstance)]
    public class Chat : Activity
    {
        private ChatServices chatServices;

        private MessageBroadcastReceiver messageBroadcastReceiver;

        [InjectView(Resource.Id.rvMessages)] private RecyclerView rvMessages;

        [InjectView(Resource.Id.edtContent)] private EditText edtContent;

        [InjectOnClick(Resource.Id.btnSignOut)]
        private void SignOut(object sender, EventArgs e)
        {
            DataManager.GetInstance.AppData.LoggedStatus = false;
            StartActivity(typeof(Login));
        }

        [InjectOnClick(Resource.Id.btnSend)]
        private void Send(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(edtContent.Text)) return; 
            chatServices.Send(edtContent.Text, DataManager.GetInstance.AppData.UserName);

            DataManager.GetInstance.AppData.Messages.Add(edtContent.Text);
            adapter.NotifyDataSetChanged();
            rvMessages.ScrollToPosition(DataManager.GetInstance.AppData.Messages.Count - 1);
            edtContent.Text = string.Empty;
            var inputManager = (InputMethodManager)GetSystemService(InputMethodService);
            inputManager.HideSoftInputFromWindow(CurrentFocus.WindowToken, HideSoftInputFlags.NotAlways);
        }

        private ChatAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChatLayout);
            Cheeseknife.Inject(this);
            Init();
        }

        private void Init()
        {
            rvMessages.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new ChatAdapter(DataManager.GetInstance.AppData.Messages);
            rvMessages.SetAdapter(adapter);
            messageBroadcastReceiver = new MessageBroadcastReceiver();
            chatServices = new ChatServices();
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
            Log.Info("message", intent.GetStringExtra("message"));
            Log.Info("from", intent.GetStringExtra("from"));

            DataManager.GetInstance.AppData.Messages.Add(intent.GetStringExtra("message"));
            adapter.NotifyDataSetChanged();
        }

        public override void OnBackPressed()
        {
        }
    }
}