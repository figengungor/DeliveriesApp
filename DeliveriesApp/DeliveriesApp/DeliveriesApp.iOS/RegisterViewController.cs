using Foundation;
using System;
using UIKit;
using DeliveriesApp.iOS;

namespace DeliveriesApp.iOS
{
    public partial class RegisterViewController : UIViewController
    {
        public string emailAddress;
        UIAlertController alert;


        public RegisterViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            emailTextField.Text = emailAddress;

            registerButton.TouchUpInside += RegisterButton_TouchUpInside;
        }

        private async void RegisterButton_TouchUpInside(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTextField.Text) || string.IsNullOrEmpty(confirmPasswordTextField.Text)
            || string.IsNullOrEmpty(emailTextField.Text))
            {
                alert = UIAlertController.Create("Error", "Fields cannot be empty!", UIAlertControllerStyle.Alert);
                var cancelAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null);
                alert.AddAction(cancelAction);
                PresentViewController(alert, true, null);
                return;
            }

            if (passwordTextField.Text == confirmPasswordTextField.Text)
            {
                var user = new User()
                {
                    Email = emailTextField.Text,
                    Password = passwordTextField.Text
                };

                await AppDelegate.MobileService.GetTable<User>().InsertAsync(user);

                alert = UIAlertController.Create("Error", "User inserted!", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
                PresentViewController(alert, true, null);

                return;
            }

            alert = UIAlertController.Create("Error", "Password don't match", UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, true, null);

        }

    }

}