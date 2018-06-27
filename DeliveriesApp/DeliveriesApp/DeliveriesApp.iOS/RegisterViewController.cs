using System;
using UIKit;
using DeliveriesApp.Model;

namespace DeliveriesApp.iOS
{
    public partial class RegisterViewController : UIViewController
    {
        public string emailAddress;

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
                DisplayAlert("Error", "Fields cannot be empty!");
                return;
            }

            var result = await User.Register(emailTextField.Text, passwordTextField.Text, confirmPasswordTextField.Text);
            if (result)
            {
                DisplayAlert("Success", "User is registered!");
            }
            else
            {
                DisplayAlert("Error", "Passwords don't match!");
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