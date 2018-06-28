using System;
using DeliveriesApp.Model;
using Foundation;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class ViewController : UIViewController
    {
        bool hasLoggedIn = false;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        //very similar to onCreate in Android
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            signinButton.TouchUpInside += SigninButton_TouchUpInside;
        }

        private async void SigninButton_TouchUpInside(object sender, EventArgs e)
        {
            var email = emailTextField.Text;
            var password = passwordTextField.Text;
            
            var result = await User.Login(email, password);
            if (result)
            {
                hasLoggedIn = true;
                PerformSegue("loginSegue", this);
                // DisplayAlert("Info", "Login succesfull!");            
            }
            else
            {
                DisplayAlert("Error", "Couldn't login!");
            }
           
        }

        private void DisplayAlert(string title, string message)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, true, null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "registerSegue")
            {
                var destinationViewController = segue.DestinationViewController as RegisterViewController;
                destinationViewController.emailAddress = emailTextField.Text;
            }
        }

        public override bool ShouldPerformSegue(string segueIdentifier, NSObject sender)
        {
            if (segueIdentifier == "loginSegue")
            {
                return hasLoggedIn;
            }
            return true;
        }

        //is going to be executed when the app consuming more memory that allowed 
        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
