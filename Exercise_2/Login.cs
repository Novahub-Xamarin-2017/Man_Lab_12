using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace Exercise_2
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        [InjectOnClick(Resource.Id.btnRegister)]
        private void SignUp(object sender, EventArgs e)
        {
            StartActivity(typeof(Register));
        }

        [InjectOnClick(Resource.Id.btnLogin)]
        private void SignIn(object sender, EventArgs e)
        {
            Toast.MakeText(this, "Login", ToastLength.Short).Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Login);
            Cheeseknife.Inject(this);
        }
    }
}