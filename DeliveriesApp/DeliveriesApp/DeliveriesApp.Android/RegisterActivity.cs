using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText emailEditText, passwordEditText, confirmPasswordEditText;
        Button registerButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Register);

            emailEditText = FindViewById<EditText>(Resource.Id.registerEmailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.registerPasswordEditText);
            confirmPasswordEditText = FindViewById<EditText>(Resource.Id.confirmPasswordEditText);
            registerButton = FindViewById<Button>(Resource.Id.registerUserButton);

            registerButton.Click += RegisterButton_Click;

            string email = Intent.GetStringExtra("email");
            emailEditText.Text = email;
        }

        private async void RegisterButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordEditText.Text) || string.IsNullOrEmpty(confirmPasswordEditText.Text)
                || string.IsNullOrEmpty(emailEditText.Text))
            {
                Toast.MakeText(this, "Fields cannot be empty!", ToastLength.Long).Show();
                return;
            }

            var result = await User.Register(emailEditText.Text, passwordEditText.Text, confirmPasswordEditText.Text);
            if (result)
            {
                Toast.MakeText(this, "User is registered!", ToastLength.Long).Show();             
            }
            else
            {
                Toast.MakeText(this, "Passwords don't match!", ToastLength.Long).Show();             
            }

        }
    }
}