// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace DeliveriesApp.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton helloButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField nameTextField { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (helloButton != null) {
                helloButton.Dispose ();
                helloButton = null;
            }

            if (nameTextField != null) {
                nameTextField.Dispose ();
                nameTextField = null;
            }
        }
    }
}