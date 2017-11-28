using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CustomNavigationBarSample;
using CustomNavigationBarSample.iOS.Renderers;
using CoreGraphics;

//[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationRenderer))]
namespace CustomNavigationBarSample.iOS.Renderers
{
    public class CustomNavigationRenderer : NavigationRenderer
    {
        Page lastPage = null;
        bool isPushed = false;
        protected override async Task<bool> OnPushAsync(Page page, bool animated)
        {
         
            isPushed = true;
            page.PropertyChanged -= Page_PropertyChanged;
            page.PropertyChanged += Page_PropertyChanged;
            var task = await base.OnPushAsync(page, animated);
         
            return task;
        }

      

        private void Page_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(e.PropertyName);
            /*TopViewController.NavigationItem.TitleView = new UILabel(new CGRect(0, 0, this.NavigationBar.Bounds.Width, this.NavigationBar.Bounds.Height))
            {
                TextAlignment = UITextAlignment.Left,
                Font = UIFont.SystemFontOfSize(14),
                Text = lastPage.Title,
                TextColor = UIColor.Black
            };*/
        }

        public override void ViewWillLayoutSubviews()
        {
            if(isPushed)
            {
                lastPage = Element?.Navigation?.NavigationStack?.Last();
            }
            else if (Element?.Navigation?.NavigationStack?.Count() >= 2)
            {
             
                lastPage = Element?.Navigation?.NavigationStack[Element.Navigation.NavigationStack.Count() - 2];
           

            }
        
     
            base.ViewWillLayoutSubviews();
        }
        public override void ViewDidLayoutSubviews()
        {

            base.ViewDidLayoutSubviews();
        }
        protected override Task<bool> OnPopToRoot(Page page, bool animated)
        {
            isPushed = false;
            page.PropertyChanged -= Page_PropertyChanged;
            return base.OnPopToRoot(page, animated);
        }

        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            isPushed = false;

            page.PropertyChanged -= Page_PropertyChanged;
            return base.OnPopViewAsync(page, animated);
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
        }
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            lastPage = ((NavigationPage)Element).CurrentPage;
            Element.PropertyChanged += Element_PropertyChanged;
        }

        private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
           if (e.PropertyName == NavigationPage.CurrentPageProperty.PropertyName)
           {
                lastPage = ((NavigationPage)Element).CurrentPage;
              
            }
            System.Diagnostics.Debug.WriteLine($" ROOT - {e.PropertyName}");

        }
    }
}