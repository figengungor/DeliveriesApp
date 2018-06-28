// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DeliveriesApp.iOS
{
    [Register ("DeliveriesViewController")]
    partial class DeliveriesViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Deliveries { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Deliveries != null) {
                Deliveries.Dispose ();
                Deliveries = null;
            }
        }
    }
}