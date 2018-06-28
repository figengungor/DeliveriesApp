using DeliveriesApp.Model;
using Foundation;
using System;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class NewDeliveryViewController : UIViewController
    {
        public NewDeliveryViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            saveBarButtonItem.Clicked += SaveBarButtonItem_Clicked;
        }

        private async void SaveBarButtonItem_Clicked(object sender, EventArgs e)
        {
            Delivery delivery = new Delivery()
            {
                Name = packageNameTextField.Text,
                Status = 0
            };
            bool result = await Delivery.InsertDelivery(delivery);
            if (result)
            {
                DisplayAlert("Success", "Delivery is saved!");
            }
            else
            {
                DisplayAlert("Error", "Delivery couldn't be saved");
            }
        }

        private void DisplayAlert(string title, string message)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, true, null);
        }
    }
}