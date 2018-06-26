using System;
using System.Linq;
using Foundation;
using UIKit;

namespace DeliveriesApp.iOS
{
    public partial class ViewController : UIViewController
    {

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

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                DisplayAlert("Error", "Fields cannot be empty!");
            }
            else
            {
                //First() generates an exception if user doesnt exist, FirtOrDefault return null if user doesn't exist
                var user = (await AppDelegate.MobileService.GetTable<User>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        DisplayAlert("Info", "Login succesfull!");
                    }
                    else
                    {
                        DisplayAlert("Error", "Email or password incorrect!");
                    }
                }
                else
                {
                    DisplayAlert("Error", "Email or password incorrect!");
                }

            }
        }

        private void DisplayAlert(string title, string message)
        {
            var alert = UIAlertController.Create(title, message, UIAlertControllerStyle.Alert);
            alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null));
            PresentViewController(alert, true, null);
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if(segue.Identifier == "registerSegue")
            {
                var destinationViewController = segue.DestinationViewController as RegisterViewController;
                destinationViewController.emailAddress = emailTextField.Text;
            }
        }

        //is going to be executed when the app consuming more memory that allowed 
        public override void DidReceiveMemoryWarning() 
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
