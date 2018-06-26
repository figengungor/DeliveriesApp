using System;
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
            registerButton.TouchUpInside += RegisterButton_TouchUpInside;
            
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

        private void RegisterButton_TouchUpInside(object sender, EventArgs e)
        {
          
        }

        private void SigninButton_TouchUpInside(object sender, EventArgs e)
        {
            
        }


        //is going to be executed when the app consuming more memory that allowed 
        public override void DidReceiveMemoryWarning() 
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
