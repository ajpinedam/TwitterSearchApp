using System;
using FFImageLoading;
using Foundation;
using TwitterSearchApp.Core;
using UIKit;

namespace TwitterSearchApp.iOS
{
    public partial class ResultsTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString ("ResultsTableViewCell");
        public static readonly UINib Nib;

        static ResultsTableViewCell ()
        {
            Nib = UINib.FromName ("ResultsTableViewCell", NSBundle.MainBundle);
        }

        protected ResultsTableViewCell (IntPtr handle) : base (handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public void FillView (SearchResult searchResult)
        {
            ResultImageView.RoundImage ();

            TwittText.Text = searchResult.TwitterText;
            TwittDetail.Text = $"{searchResult.UserId} @ {searchResult.DatePosted?.ToUniversalTime():D}";
            ImageService.Instance.LoadUrl (searchResult.ImageUrl)
                        .LoadingPlaceholder ("loading-small.png")
                        .Into (ResultImageView);
        }
    }
}
