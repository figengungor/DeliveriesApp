using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveriesApp.Model;

namespace DeliveriesApp.Droid
{
    [Activity(Label = "NewActivity")]
    public class NewDeliveryActivity : Activity
    {
        Button saveButton;
        EditText packageNameEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.NewDelivery);

            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            packageNameEditText = FindViewById<EditText>(Resource.Id.packageNameEditText);

            saveButton.Click += SaveButton_Click;
        }

        private async void SaveButton_Click(object sender, EventArgs e)
        {
            var packageName = packageNameEditText.Text;
            if (string.IsNullOrEmpty(packageName))
            {
                Toast.MakeText(this, "Package name can't be empty!", ToastLength.Long);
            }
            else
            {
                Delivery delivery = new Delivery()
                {
                    Name = packageName,
                    Status = 0
                };

                var result = await Delivery.InsertDelivery(delivery);
                if (result)
                {
                    Toast.MakeText(this, "Delivery is saved!", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "Delivery couldn't be saved!", ToastLength.Long).Show();
                }
            }
        }
    }
}