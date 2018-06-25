using System;

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

            helloButton.TouchUpInside += HelloButton_TouchUpInside;
            
        }

        private void HelloButton_TouchUpInside(object sender, EventArgs e)
        {
            //create an alert
            var alert = UIAlertController.Create("Hello", $"Hello {nameTextField.Text}", UIAlertControllerStyle.Alert);

            var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, null);

            alert.AddAction(cancelAction);

            PresentViewController(alert, true, null); //display alert, true for animation, null for completion handler
        }

        //is going to be executed when the app consuming more memory that allowed 
        public override void DidReceiveMemoryWarning() 
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.		
        }
    }
}
