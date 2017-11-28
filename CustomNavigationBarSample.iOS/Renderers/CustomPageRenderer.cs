using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using CustomNavigationBarSample.iOS.Renderers;
using CustomNavigationBarSample;

[assembly: ExportRenderer(typeof(CustomPage),typeof(CustomPageRenderer))]
namespace CustomNavigationBarSample.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            if (!string.IsNullOrEmpty(title))
            {
                Device.BeginInvokeOnMainThread(() => {
                    var labelView = new UIKit.UILabel()
                    {
                        Frame = new CoreGraphics.CGRect(0, 0, 70, 30),
                        BackgroundColor = UIColor.Clear,
                        TextColor = UIColor.White,
                        TextAlignment = UITextAlignment.Center,
                        Text = title
                    };

                    var bordeView = new UIKit.UIView()
                    {
                        Frame = new CoreGraphics.CGRect(0, 0, 70, 30),
                        BackgroundColor = UIColor.FromRGB(188, 195, 204),
                        ContentMode = UIViewContentMode.ScaleAspectFit
                    };
                    bordeView.Layer.CornerRadius = 15;
                    bordeView.Add(labelView);
                    NavigationController.NavigationBar.TopItem.TitleView = bordeView;
                });
            }
        }

        string title = string.Empty;
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }

        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            NavigationController.NavigationBar.TopItem.TitleView = null;
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.iOS.VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            title = ((Xamarin.Forms.Page)Element).Title;
            ((Xamarin.Forms.Page)Element).Title = string.Empty;

        }


    }
}