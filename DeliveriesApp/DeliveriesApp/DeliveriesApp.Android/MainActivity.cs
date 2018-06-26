using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Microsoft.WindowsAzure.MobileServices;
using System.Linq;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "DeliveriesApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText emailEditText;
        EditText passwordEditText;
        Button signinButton;
        Button registerButton;

        public static MobileServiceClient MobileService = new MobileServiceClient("https://deliveriesappfig.azurewebsites.net");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            emailEditText = FindViewById<EditText>(Resource.Id.emailEditText);
            passwordEditText = FindViewById<EditText>(Resource.Id.passwordEditText);
            signinButton = FindViewById<Button>(Resource.Id.signinButton);
            registerButton = FindViewById<Button>(Resource.Id.registerButton);

            signinButton.Click += SigninButton_Click;
            registerButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(RegisterActivity));
            intent.PutExtra("email", emailEditText.Text);
            StartActivity(intent);
        }

        private async void SigninButton_Click(object sender, System.EventArgs e)
        {
            var email = emailEditText.Text;
            var password = passwordEditText.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                Toast.MakeText(this, "Fields cannot be empty!", ToastLength.Long).Show();
            }
            else
            {
                //First() generates an exception if user doesnt exist, FirtOrDefault return null if user doesn't exist
                var user = (await MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        Toast.MakeText(this, "Login succesfull!", ToastLength.Long).Show();
                    }
                    else
                    {
                        Toast.MakeText(this, "Email or password incorrect!", ToastLength.Long).Show();
                    }
                }
                else
                {
                    Toast.MakeText(this, "Email or password incorrect!", ToastLength.Long).Show();
                }

            }

        }
    }
}

