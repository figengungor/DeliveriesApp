﻿// WARNING
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
    [Register ("ProfileViewController")]
    partial class ProfileViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITabBarItem Profile { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (Profile != null) {
                Profile.Dispose ();
                Profile = null;
            }
        }
    }
}