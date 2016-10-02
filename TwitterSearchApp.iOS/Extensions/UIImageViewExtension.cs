using UIKit;

namespace TwitterSearchApp.iOS
{
    public static class UIImageViewExtension
    {
        public static void RoundImage (this UIImageView imageView)
        {
            imageView.Layer.CornerRadius = imageView.Frame.Size.Width / 2;
            imageView.ClipsToBounds = true;
        }
    }
}
