using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Exercise_2.Models;
using Exercise_2.Services;

namespace Exercise_2
{
    [Activity(Label = "Register")]
    public class Register : Activity
    {
        private ChatServices services = new ChatServices();

        [InjectView(Resource.Id.edtFullnameRegister)] private EditText edtFullName;

        [InjectView(Resource.Id.edtUserRegister)] private EditText edtUser;

        [InjectView(Resource.Id.edtPasswordRegister)] private EditText edtPassword;

        [InjectOnClick(Resource.Id.btnLogin)]
        private void SignIn(object sender, EventArgs e)
        {
            Finish();
        }

        [InjectOnClick(Resource.Id.btnRegister)]
        private void SignUp(object sender, EventArgs e)
        {
            var signUpForm = new SignUpForm
            {
                FullName = edtFullName.Text,
                UserName = edtUser.Text,
                Password = edtPassword.Text
            };
            if (services.SignUp(signUpForm))
            {
                Toast.MakeText(this, "Sign Up Successfully", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Sign Up Failed", ToastLength.Short).Show();
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Register);
            Cheeseknife.Inject(this);
            // Create your application here
        }
    }
}