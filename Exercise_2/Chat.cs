using System;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views.InputMethods;
using Android.Widget;
using Exercise_2.Adapter;
using Exercise_2.Services;

namespace Exercise_2
{
    [Activity(Label = "Chat")]
    public class Chat : Activity
    {
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
            // Create your application here
        }

        private void Init()
        {
            rvMessages.SetLayoutManager(new LinearLayoutManager(this));
            adapter = new ChatAdapter(DataManager.GetInstance.AppData.Messages);
            rvMessages.SetAdapter(adapter);
        }
        public override void OnBackPressed()
        {
        }
    }
}