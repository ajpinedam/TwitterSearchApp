// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TwitterSearchApp.iOS
{
    [Register ("ResultsTableViewCell")]
    partial class ResultsTableViewCell
    {
        [Outlet]
        UIKit.UIImageView ResultImageView { get; set; }


        [Outlet]
        UIKit.UILabel TwittDetail { get; set; }


        [Outlet]
        UIKit.UILabel TwittText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (ResultImageView != null) {
                ResultImageView.Dispose ();
                ResultImageView = null;
            }

            if (TwittDetail != null) {
                TwittDetail.Dispose ();
                TwittDetail = null;
            }

            if (TwittText != null) {
                TwittText.Dispose ();
                TwittText = null;
            }
        }
    }
}