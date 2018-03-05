using System;
using System.Net;
using Android.App;
using Android.OS;
using Android.Widget;
using Exercise_2.Models;
using Exercise_2.Services;
using Firebase.Iid;
using RestSharp;

namespace Exercise_2
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        private ChatServices services = new ChatServices();

        [InjectView(Resource.Id.edtUserLogin)] private TextView edtUser;

        [InjectView(Resource.Id.edtPasswordLogin)] private TextView edtPassword;

        [InjectOnClick(Resource.Id.btnRegister)]
        private void SignUp(object sender, EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        [InjectOnClick(Resource.Id.btnLogin)]
        private void SignIn(object sender, EventArgs e)
        {
            var signInForm = new SignInForm
            {
                UserName = edtUser.Text,
                Password = edtPassword.Text,
                FirebaseToken = ""
            };
            if (services.SignIn(signInForm))
                StartActivity(typeof(Chat));
            else
                Toast.MakeText(this, "Login Failed", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            Cheeseknife.Inject(this);
        }
    }
}