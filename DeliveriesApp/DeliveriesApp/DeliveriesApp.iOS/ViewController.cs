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
