using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CustomNavigationBarSample;
using CustomNavigationBarSample.iOS.Renderers;
using CoreGraphics;
using CoreAnimation;

[assembly: ExportRenderer(typeof(ContentPage), typeof(CustomPageRenderer))]

namespace CustomNavigationBarSample.iOS.Renderers
{
   public class CustomPageRenderer : PageRenderer
    {
        UILabel titleLabel;
        UILabel subtitleLabel;
        UIView containerView;
        UIView titleView;
        UIView marginView;
        nfloat lastNavBarHeight = 0.0f;
        nfloat lastNavBarWidth = 0.0f;
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            System.Diagnostics.Debug.WriteLine("Element");
        }
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
           
            SetupNavBar(NavigationController.NavigationBar.Bounds.Size);
            SetTitlePosition(CustomNavigationPage.GetTitlePosition(Element), CustomNavigationPage.GetTitlePadding(Element), CustomNavigationPage.GetTitleMargin(Element), new CGRect(0, 0, Math.Max(subtitleLabel.IntrinsicContentSize.Width, titleLabel.IntrinsicContentSize.Width), (titleLabel.IntrinsicContentSize.Height + subtitleLabel.IntrinsicContentSize.Height + (subtitleLabel.IntrinsicContentSize.Height > 0.0f ? 3.0f : 0.0f))));
            
            System.Diagnostics.Debug.WriteLine("Preparing");
        }
        public override void ViewWillLayoutSubviews()
        {
            base.ViewWillLayoutSubviews();
            System.Diagnostics.Debug.WriteLine("SubViews");
        }
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            if(lastNavBarWidth != NavigationController?.NavigationBar?.Bounds.Size.Width || lastNavBarHeight != NavigationController?.NavigationBar?.Bounds.Size.Height)
            {
                lastNavBarHeight = NavigationController?.NavigationBar?.Bounds.Size.Height ?? 0.0f;
                lastNavBarWidth = NavigationController?.NavigationBar?.Bounds.Size.Width ?? 0.0f;
                SetupNavBar(new CGSize(lastNavBarWidth, lastNavBarHeight));

            }
            
            SetTitlePosition( CustomNavigationPage.GetTitlePosition(Element), CustomNavigationPage.GetTitlePadding(Element),CustomNavigationPage.GetTitleMargin(Element), new CGRect(0, 0, Math.Max(subtitleLabel.IntrinsicContentSize.Width, titleLabel.IntrinsicContentSize.Width), (titleLabel.IntrinsicContentSize.Height + subtitleLabel.IntrinsicContentSize.Height + (subtitleLabel.IntrinsicContentSize.Height > 0.0f ? 3.0f : 0.0f))));

            System.Diagnostics.Debug.WriteLine("didSubViews");
        
           
   
        }
        void SetupNavBar(CGSize size)
        {
            if (NavigationController != null && titleView != null)
            {
                var page = Element as Page;
                containerView.Frame = new CGRect(0, 0, size.Width, size.Height);


                titleView.Layer.BorderWidth = CustomNavigationPage.GetTitleBorderWidth(Element);

                titleView.Layer.CornerRadius = CustomNavigationPage.GetTitleBorderCornerRadius(Element);

                titleView.Layer.BorderColor = CustomNavigationPage.GetTitleBorderColor(Element)?.ToCGColor() ?? UIColor.Clear.CGColor;



                SetupTextFont(titleLabel, CustomNavigationPage.GetTitleFont(page), CustomNavigationPage.GetTitleColor(page));

                SetupBackground();

                if (!string.IsNullOrEmpty(CustomNavigationPage.GetTitleBackground(Element)))
                {
                    try
                    {

                        var image = UIImage.FromBundle(CustomNavigationPage.GetTitleBackground(Element));
                        titleView.Frame = new CGRect(titleView.Frame.X, titleView.Frame.Y, titleView.Frame.Width == 0?Math.Min(size.Width,image.Size.Width): Math.Min(titleView.Frame.Width, image.Size.Width), titleView.Frame.Height == 0 ? Math.Min(size.Height, image.Size.Height) : Math.Min(titleView.Frame.Height, image.Size.Height));
                      
                        titleView.BackgroundColor = UIColor.FromPatternImage(image);
                
                    }
                    catch (Exception ex)
                    {
                        titleView.BackgroundColor = CustomNavigationPage.GetTitleFillColor(Element)?.ToUIColor() ?? UIColor.Clear;

                    }

                }
                else
                {
                    titleView.BackgroundColor = CustomNavigationPage.GetTitleFillColor(Element)?.ToUIColor() ?? UIColor.Clear;
                }

           
                ParentViewController.NavigationItem.TitleView = containerView;
                ParentViewController.NavigationItem.TitleView.SetNeedsDisplay();
            }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            containerView = new UIView()
            {
                AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth
            };
            
            titleView = new UIView()
            {
                
            };

            marginView = new UIView()
            {
        
            };

            titleLabel = new UILabel()
            {
                Text = Title
                
            };

            subtitleLabel = new UILabel()
            {
                Hidden = true
            };
         
            titleView.Add(titleLabel);
            titleView.Add(subtitleLabel);
            marginView.Add(titleView);
            containerView.Add(marginView);

            Element.PropertyChanged += Element_PropertyChanged;
        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
       
        }
        void SetTitlePosition( CustomNavigationPage.TitleAlignment alignment,Thickness padding, Thickness margin, CGRect vFrame)
        {
            
            var marginX = margin.Top;
            var marginY = margin.Left;
            var marginWidth = margin.Left + margin.Right;
            var marginHeight = margin.Top + margin.Bottom;
            var paddingWidth = padding.Left + padding.Right;
            var paddingHeight = padding.Top + padding.Bottom;
            var paddingX = padding.Left;
            var paddingY = padding.Top;

            if(CustomNavigationPage.GetTitleBackground(Element) !=null && vFrame.Width == 0 && vFrame.Height == 0)
            {
                vFrame = titleView.Frame;
            }


            marginView.Frame = new CGRect(vFrame.X, vFrame.Y, vFrame.Width, vFrame.Height);
            

            

            double offset = 0;
            
            titleLabel.AutoresizingMask = UIViewAutoresizing.All;
            switch (alignment)
            {
                case CustomNavigationPage.TitleAlignment.Start:
                    marginView.Frame = new CGRect( vFrame.X, marginView.Frame.Y, marginView.Bounds.Width + marginWidth + paddingWidth, marginView.Bounds.Height + marginHeight + paddingHeight);
                    var startCenter = marginView.Center;
                    startCenter.Y = marginView.Superview.Center.Y;
                    marginView.Center = startCenter;
                    titleLabel.TextAlignment = UITextAlignment.Left;
                    subtitleLabel.TextAlignment = UITextAlignment.Left;
                    offset = marginX;
                    break;
                case CustomNavigationPage.TitleAlignment.Center:
                    offset = marginX;
                    marginView.Frame = new CGRect(marginView.Frame.X , marginView.Frame.Y , marginView.Bounds.Width + marginWidth + paddingWidth, marginView.Bounds.Height + marginHeight + paddingHeight);
                    marginView.Center = marginView.Superview.Center;
                    titleLabel.TextAlignment = UITextAlignment.Center;
                    subtitleLabel.TextAlignment = UITextAlignment.Center;
                    break;
                case CustomNavigationPage.TitleAlignment.End:
                    
                    var endCenter = marginView.Center;
                    endCenter.Y = marginView.Superview.Center.Y;
                    marginView.Center = endCenter;

                    titleLabel.TextAlignment = UITextAlignment.Right;
                    subtitleLabel.TextAlignment = UITextAlignment.Right;
                    marginView.Frame = new CGRect(marginView.Superview.Frame.Width - marginView.Frame.Width - offset -marginWidth-paddingWidth, marginView.Frame.Y , marginView.Bounds.Width + marginWidth + paddingWidth, marginView.Bounds.Height +marginHeight + paddingHeight);
                    offset = marginView.Frame.Width - vFrame.Width - paddingWidth - marginX;
                    break;
            }
          
            titleView.Frame = new CGRect(offset , vFrame.Y + marginY, vFrame.Width + paddingWidth, vFrame.Height + paddingHeight);

            var cPage = Element as CustomPage;



            if (cPage != null && (!string.IsNullOrEmpty(cPage.Subtitle) || (cPage.FormattedSubtitle != null && cPage.FormattedSubtitle.Spans.Count > 0)))
            {

                
                titleLabel.Frame = new CGRect(paddingX, paddingY, titleView.Frame.Width , titleLabel.IntrinsicContentSize.Height);


                subtitleLabel.Frame = new CGRect(titleLabel.Frame.X, titleLabel.Frame.Y+titleLabel.Frame.Height + 3, titleView.Frame.Width, subtitleLabel.Frame.Height);
            
            }
            else
            {
                
                titleLabel.Frame = new CGRect(paddingX, paddingY, titleLabel.IntrinsicContentSize.Width, titleLabel.IntrinsicContentSize.Height );
      
            }
          
        }
       
        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);
            SetupNavBar(new CGSize(NavigationController?.NavigationBar?.Bounds.Size.Width ?? 0.0f, NavigationController?.NavigationBar?.Bounds.Height ?? 0.0f));


        }
        UIImage CreateGradientBackground(Color startColor, Color endColor, CustomNavigationPage.GradientDirection direction)
        {
            var gradientLayer = new CAGradientLayer();
            gradientLayer.Bounds = NavigationController.NavigationBar.Bounds;
            gradientLayer.Colors = new CGColor[] { startColor.ToCGColor(), endColor.ToCGColor() };

            switch(direction)
            {
                case CustomNavigationPage.GradientDirection.LeftToRight:
                    gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
                    break;
                case CustomNavigationPage.GradientDirection.RightToLeft:
                    gradientLayer.StartPoint = new CGPoint(1.0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(0.0, 0.5);
                    break;
                case CustomNavigationPage.GradientDirection.BottomToTop:
                    gradientLayer.StartPoint = new CGPoint(1.0, 1.0);
                    gradientLayer.EndPoint = new CGPoint(0.0, 0.0);
                    break;
                default:
                    gradientLayer.StartPoint = new CGPoint(1.0, 0.0);
                    gradientLayer.EndPoint = new CGPoint(0.0, 1.0);
                    break;
            }

            UIGraphics.BeginImageContext(gradientLayer.Bounds.Size);
            gradientLayer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();


            return image;
            
        }
        public override void ViewDidDisappear(bool animated)
        {
            base.ViewDidDisappear(animated);
        }
        void SetupShadow(bool hasShadow)
        {
            if(hasShadow)
            {
                NavigationController.NavigationBar.Layer.ShadowColor = UIColor.Gray.CGColor;
                NavigationController.NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
                NavigationController.NavigationBar.Layer.ShadowOpacity = 1;
            }
            else
            {
                NavigationController.NavigationBar.Layer.ShadowColor = UIColor.Clear.CGColor;
                NavigationController.NavigationBar.Layer.ShadowOffset = new CGSize(0, 0);
                NavigationController.NavigationBar.Layer.ShadowOpacity = 0;
            }
           
        }

        void SetupBackground(UIImage image,float alpha)
        {
            NavigationController.NavigationBar.SetBackgroundImage(image, UIBarMetrics.Default);
            NavigationController.NavigationBar.Alpha = alpha;
        }
        void SetupBackground()
        {
            if (string.IsNullOrEmpty(CustomNavigationPage.GetBarBackground(Element)) && CustomNavigationPage.GetGradientColors(Element) == null)
            {
             
                SetupBackground(null, CustomNavigationPage.GetBarBackgroundOpacity(Element));
            }
            else
            {
                if (!string.IsNullOrEmpty(CustomNavigationPage.GetBarBackground(Element)))
                {
                    SetupBackground(UIImage.FromBundle(CustomNavigationPage.GetBarBackground(Element)), CustomNavigationPage.GetBarBackgroundOpacity(Element));
                }
                else if (CustomNavigationPage.GetGradientColors(Element) != null)
                {
                    SetupBackground(CreateGradientBackground(CustomNavigationPage.GetGradientColors(Element).Item1, CustomNavigationPage.GetGradientColors(Element).Item2, CustomNavigationPage.GetGradientDirection(Element)), CustomNavigationPage.GetBarBackgroundOpacity(Element));

                }
            }
        }

        void SetupTextFont(UILabel label,Font font,Color? titleColor)
        {
           
            var cPage = Element as CustomPage;
            if (cPage!=null && cPage.FormattedTitle != null && cPage.FormattedTitle.Spans.Count > 0)
            {
                SetupFormattedText(titleLabel, cPage.FormattedTitle, cPage.Title);
            }
            else
            {
                SetupText(label, (Element as Page).Title,titleColor, CustomNavigationPage.GetTitleFont(Element));

            }

            if (cPage != null && cPage.FormattedSubtitle != null && cPage.FormattedSubtitle.Spans.Count > 0)
            {
                subtitleLabel.Hidden = false;
                SetupFormattedText(subtitleLabel, cPage.FormattedSubtitle, cPage.Subtitle);
          
            }
            else if (cPage != null && !string.IsNullOrEmpty(cPage.Subtitle))
            {
                subtitleLabel.Hidden = false;
                SetupText(subtitleLabel, cPage.Subtitle, CustomNavigationPage.GetSubtitleColor(cPage), CustomNavigationPage.GetSubtitleFont(Element));
            
                subtitleLabel.SetNeedsDisplay();
            }
            else
            {
                subtitleLabel.Text = string.Empty;
                subtitleLabel.Frame = CGRect.Empty;
                subtitleLabel.Hidden = true;
            }


            label.SizeToFit();
            subtitleLabel.SizeToFit();
            titleView.SizeToFit();

        }
        void SetupTextColor(UILabel label,UIColor color)
        {
            label.TextColor = color;
        }

        void SetupFormattedText(UILabel label, FormattedString formattedString, string defaulTitle)
        {
                label.AttributedText = formattedString.ToAttributed(Font.Default, Xamarin.Forms.Color.Default);
                label.SetNeedsDisplay();
        }

        void SetupText(UILabel label, string text,Color? textColor, Font font)
        {
     
            if (!string.IsNullOrEmpty(text))
            {
                label.Text = text;
            }
            else
            {
                label.Text = string.Empty;
                label.AttributedText = new NSAttributedString();
            }

            if(textColor !=null)
            {
                label.TextColor = textColor?.ToUIColor();
            }
          
            label.Font = font.ToUIFont();
        }
        private void Element_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var page = sender as Page;
            System.Diagnostics.Debug.WriteLine(e.PropertyName);
            if (e.PropertyName == Page.TitleProperty.PropertyName  || e.PropertyName == CustomNavigationPage.TitleFontProperty.PropertyName || e.PropertyName == CustomPage.SubtitleProperty.PropertyName || e.PropertyName == CustomNavigationPage.SubtitleFontProperty.PropertyName)
            {
                 SetupTextFont(titleLabel, CustomNavigationPage.GetTitleFont(page), CustomNavigationPage.GetTitleColor(page));

                SetTitlePosition(CustomNavigationPage.GetTitlePosition(page), CustomNavigationPage.GetTitlePadding(Element), CustomNavigationPage.GetTitleMargin(Element), new CGRect(0, 0, Math.Max(subtitleLabel.IntrinsicContentSize.Width, titleLabel.IntrinsicContentSize.Width), (titleLabel.IntrinsicContentSize.Height + subtitleLabel.IntrinsicContentSize.Height + (subtitleLabel.IntrinsicContentSize.Height > 0.0f ? 3.0f : 0.0f))));

            }
            else if (e.PropertyName == CustomNavigationPage.TitleColorProperty.PropertyName)
            {
                var color =CustomNavigationPage.GetTitleColor(page);
                if (color !=null)
                {
                    titleLabel.TextColor = color?.ToUIColor();
                }


            }
            else if (e.PropertyName == CustomNavigationPage.SubtitleColorProperty.PropertyName)
            {
                var color = CustomNavigationPage.GetSubtitleColor(page);
                if (color != null)
                {
                    subtitleLabel.TextColor = color?.ToUIColor();
                }


            }
            else if (e.PropertyName == CustomNavigationPage.TitlePositionProperty.PropertyName || e.PropertyName == CustomNavigationPage.TitlePaddingProperty.PropertyName || e.PropertyName == CustomNavigationPage.TitleMarginProperty.PropertyName)
            {

                SetTitlePosition(CustomNavigationPage.GetTitlePosition(Element), CustomNavigationPage.GetTitlePadding(Element), CustomNavigationPage.GetTitleMargin(Element), new CGRect(0, 0, Math.Max(subtitleLabel.IntrinsicContentSize.Width, titleLabel.IntrinsicContentSize.Width), (titleLabel.IntrinsicContentSize.Height + subtitleLabel.IntrinsicContentSize.Height + (subtitleLabel.IntrinsicContentSize.Height > 0.0f ? 3.0f : 0.0f))));


            }
            else if (e.PropertyName == CustomNavigationPage.GradientColorsProperty.PropertyName || e.PropertyName == CustomNavigationPage.GradientDirectionProperty.PropertyName || e.PropertyName == CustomNavigationPage.BarBackgroundProperty.PropertyName || e.PropertyName == CustomNavigationPage.BarBackgroundOpacityProperty.PropertyName)
            {
                SetupBackground();
            
            }
            else if (e.PropertyName == CustomNavigationPage.HasShadowProperty.PropertyName)
            {
                SetupShadow(CustomNavigationPage.GetHasShadow(page));
              
            }
            else if (e.PropertyName == CustomPage.FormattedTitleProperty.PropertyName && (page is CustomPage))
            {
                var cPage = page as CustomPage;
                SetupFormattedText(titleLabel, cPage.FormattedTitle, cPage.Title);

            }else if (e.PropertyName == CustomNavigationPage.TitleBackgroundProperty.PropertyName)
            {
                if (!string.IsNullOrEmpty(CustomNavigationPage.GetTitleBackground(Element)))
                {
                    titleView.BackgroundColor = UIColor.FromPatternImage(UIImage.FromBundle(CustomNavigationPage.GetTitleBackground(Element)));

                }
                else
                {
                    titleView.BackgroundColor = null;
                }
            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderWidthProperty.PropertyName)
            {
                titleView.Layer.BorderWidth = CustomNavigationPage.GetTitleBorderWidth(Element);
            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderCornerRadiusProperty.PropertyName)
            {
                titleView.Layer.CornerRadius = CustomNavigationPage.GetTitleBorderCornerRadius(Element);
            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderColorProperty.PropertyName)
            {
                titleView.Layer.BorderColor = CustomNavigationPage.GetTitleBorderColor(Element)?.ToCGColor()??UIColor.Clear.CGColor;
            }
            else if (e.PropertyName == CustomNavigationPage.TitleFillColorProperty.PropertyName)
            {
                titleView.BackgroundColor = CustomNavigationPage.GetTitleFillColor(Element)?.ToUIColor() ?? UIColor.Clear;
            }
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();
            titleLabel = null;
            subtitleLabel = null;
            Element.PropertyChanged -= Element_PropertyChanged;
        }
    }
}