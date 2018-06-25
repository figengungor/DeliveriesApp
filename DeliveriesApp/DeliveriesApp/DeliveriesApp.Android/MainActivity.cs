using Android.App;
using Android.Widget;
using Android.OS;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "DeliveriesApp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        EditText nameEditText;
        Button helloButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            nameEditText = FindViewById<EditText>(Resource.Id.nameEditText);
            helloButton = FindViewById<Button>(Resource.Id.helloButton);

            //add event handler for button

            helloButton.Click += HelloButton_Click;
         
        }

        private void HelloButton_Click(object sender, System.EventArgs e)
        {
            Toast.MakeText(this, $"Hello {nameEditText.Text}", ToastLength.Short).Show();
        }
    }
}

