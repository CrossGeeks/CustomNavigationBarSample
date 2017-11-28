using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using CustomNavigationBarSample;
using CustomNavigationBarSample.Droid.Renderers;
using Xamarin.Forms.Platform.Android.AppCompat;
using Xamarin.Forms.Platform.Android;
using Android.Content.Res;
using Android.Support.V4.App;
using Android.Text;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Android.Graphics;
using static Xamarin.Forms.Platform.Android.FontExtensions;
using Android.Util;
using Java.Lang;
using Android.Text.Style;

[assembly: ExportRenderer(typeof(CustomNavigationPage), typeof(CustomNavigationPageRenderer))]
namespace CustomNavigationBarSample.Droid.Renderers
{
    public class CustomNavigationPageRenderer : NavigationPageRenderer
    {
        Android.Support.V7.Widget.Toolbar _toolbar;
        LinearLayout _titleViewLayout;
        TextView _titleTextView;
        TextView _subTitleTextView;
        Android.Widget.FrameLayout _parentLayout;

        Drawable _originalDrawable;
        Drawable _originalToolbarBackground;
        Drawable _originalWindowContent;
        ColorStateList _originalColorStateList;
        Typeface _originalFont;

      
        
        protected override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
           
           // SetupToolbarCustomization(Element?.Navigation?.NavigationStack?.Last());
        }

        protected override void SetupPageTransition(Android.Support.V4.App.FragmentTransaction transaction, bool isPush)
        {
            Page lastPage = null;
            
            if (isPush)
            {
                if (Element?.Navigation?.NavigationStack?.Count() >= 2)
                {
                    var previousPage = Element?.Navigation?.NavigationStack[Element.Navigation.NavigationStack.Count() - 2];
                    previousPage.PropertyChanged -= LastPage_PropertyChanged;
                }
                
            

                lastPage = Element?.Navigation?.NavigationStack?.Last();
                SetupToolbarCustomization(lastPage);
                lastPage.PropertyChanged += LastPage_PropertyChanged;
            }
            else if (Element?.Navigation?.NavigationStack?.Count() >= 2)
            {
                var previousPage = Element?.Navigation?.NavigationStack?.Last();
                previousPage.PropertyChanged -= LastPage_PropertyChanged;

                lastPage = Element?.Navigation?.NavigationStack[Element.Navigation.NavigationStack.Count() - 2];
                lastPage.PropertyChanged += LastPage_PropertyChanged;
                SetupToolbarCustomization(lastPage);
               
            }
           

            base.SetupPageTransition(transaction, isPush);

        }

        private void LastPage_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var lastPage = sender as Page;
            if (e.PropertyName == CustomNavigationPage.HasShadowProperty.PropertyName)
            {
               UpdateToolbarShadow(_toolbar, CustomNavigationPage.GetHasShadow(lastPage),Forms.Context as Activity,_originalWindowContent);
            }
            else if (e.PropertyName == CustomNavigationPage.TitleBackgroundProperty.PropertyName)
            {
                UpdateTitleViewLayoutBackground(_titleViewLayout, CustomNavigationPage.GetTitleBackground(lastPage), _originalDrawable);

            }
            else if (e.PropertyName == CustomNavigationPage.BarBackgroundProperty.PropertyName)
            {
                UpdateToolbarBackground(_toolbar, lastPage, Forms.Context as Activity, _originalToolbarBackground);

            }
            else if (e.PropertyName == CustomNavigationPage.GradientColorsProperty.PropertyName)
            {
                UpdateToolbarBackground(_toolbar, lastPage, Forms.Context as Activity, _originalToolbarBackground);

            }
            else if (e.PropertyName == CustomNavigationPage.GradientDirectionProperty.PropertyName)
            {
                UpdateToolbarBackground(_toolbar, lastPage, Forms.Context as Activity, _originalToolbarBackground);

            }
            else if (e.PropertyName == CustomNavigationPage.BarBackgroundOpacityProperty.PropertyName)
            {
                UpdateToolbarBackground(_toolbar, lastPage, Forms.Context as Activity, _originalToolbarBackground);

            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderCornerRadiusProperty.PropertyName)
            {

                _titleViewLayout?.SetBackground(CreateShape(ShapeType.Rectangle, (int)CustomNavigationPage.GetTitleBorderWidth(lastPage), (int)CustomNavigationPage.GetTitleBorderCornerRadius(lastPage), CustomNavigationPage.GetTitleFillColor(lastPage), CustomNavigationPage.GetTitleBorderColor(lastPage)));

            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderWidthProperty.PropertyName)
            {

                _titleViewLayout?.SetBackground(CreateShape(ShapeType.Rectangle, (int)CustomNavigationPage.GetTitleBorderWidth(lastPage), (int)CustomNavigationPage.GetTitleBorderCornerRadius(lastPage), CustomNavigationPage.GetTitleFillColor(lastPage), CustomNavigationPage.GetTitleBorderColor(lastPage)));

            }
            else if (e.PropertyName == CustomNavigationPage.TitleBorderColorProperty.PropertyName)
            {

                _titleViewLayout?.SetBackground(CreateShape(ShapeType.Rectangle, (int)CustomNavigationPage.GetTitleBorderWidth(lastPage), (int)CustomNavigationPage.GetTitleBorderCornerRadius(lastPage), CustomNavigationPage.GetTitleFillColor(lastPage), CustomNavigationPage.GetTitleBorderColor(lastPage)));

            }
            else if (e.PropertyName == CustomNavigationPage.TitleFillColorProperty.PropertyName)
            {

                _titleViewLayout?.SetBackground(CreateShape(ShapeType.Rectangle, (int)CustomNavigationPage.GetTitleBorderWidth(lastPage), (int)CustomNavigationPage.GetTitleBorderCornerRadius(lastPage), CustomNavigationPage.GetTitleFillColor(lastPage), CustomNavigationPage.GetTitleBorderColor(lastPage)));

            }
            else if (e.PropertyName == CustomNavigationPage.TitlePositionProperty.PropertyName)
            {
                UpdateTitleViewLayoutAlignment(_titleViewLayout, _titleTextView, _subTitleTextView,CustomNavigationPage.GetTitlePosition(lastPage));
                //UpdateTitleViewLayout(lastPage, _titleViewLayout, _titleTextView, _subTitleTextView, _originalDrawable);




            }
            else if (e.PropertyName == CustomNavigationPage.TitlePaddingProperty.PropertyName)
            {
                UpdateTitleViewLayoutPadding(_titleViewLayout, CustomNavigationPage.GetTitlePadding(lastPage));
            }
            else if (e.PropertyName == CustomNavigationPage.TitleMarginProperty.PropertyName)
            {
                UpdateTitleViewLayoutMargin(_titleViewLayout, CustomNavigationPage.GetTitleMargin(lastPage));
            }
            else if (e.PropertyName == CustomNavigationPage.TitleColorProperty.PropertyName)
            {
                UpdateToolbarTextColor(_titleTextView, CustomNavigationPage.GetTitleColor(lastPage), _originalColorStateList);

            }
            else if (e.PropertyName == CustomNavigationPage.TitleFontProperty.PropertyName)
            {
                UpdateToolbarTextFont(_titleTextView, CustomNavigationPage.GetTitleFont(lastPage), _originalFont);

            }
            else if (e.PropertyName == Page.TitleProperty.PropertyName)
            {
                UpdateTitleText(_titleTextView, lastPage.Title);

            }
            else if (e.PropertyName == CustomPage.FormattedTitleProperty.PropertyName && (lastPage is CustomPage))
            {
                var cPage = lastPage as CustomPage;
                UpdateFormattedTitleText(_titleTextView, cPage.FormattedTitle,cPage.Title);

            }
            else if (e.PropertyName == CustomNavigationPage.SubtitleColorProperty.PropertyName)
            {
                UpdateToolbarTextColor(_subTitleTextView, CustomNavigationPage.GetSubtitleColor(lastPage), _originalColorStateList);

            }
            else if (e.PropertyName == CustomNavigationPage.SubtitleFontProperty.PropertyName)
            {
                UpdateToolbarTextFont(_subTitleTextView, CustomNavigationPage.GetSubtitleFont(lastPage), _originalFont);

            }
            else if (e.PropertyName == CustomPage.SubtitleProperty.PropertyName && (lastPage is CustomPage))
            {
                var cPage = lastPage as CustomPage;
                if (!string.IsNullOrEmpty(cPage.Subtitle))
                {
                    _subTitleTextView.Text = cPage.Subtitle;
                    _subTitleTextView.Visibility = ViewStates.Visible;
                }
                else
                {
                    ClearTextView(_subTitleTextView, true);
                }

            }
            else if (e.PropertyName == CustomPage.FormattedTitleProperty.PropertyName && (lastPage is CustomPage))
            {
                var cPage = lastPage as CustomPage;

                if (cPage.FormattedSubtitle != null && cPage.FormattedSubtitle.Spans.Count > 0)
                {
                    _subTitleTextView.TextFormatted = cPage.FormattedSubtitle.ToAttributed(Font.Default, Xamarin.Forms.Color.Default, _subTitleTextView);

                    _subTitleTextView.Visibility = ViewStates.Visible;
                }
                else
                {
                    ClearTextView(_subTitleTextView, true);
                }
                
            }
            
        }
        public override void OnViewRemoved(Android.Views.View child)
        {
            base.OnViewRemoved(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                if (_toolbar != null)
                {
                    var lastPage = Element?.Navigation?.NavigationStack?.Last();
                    _toolbar.ChildViewAdded -= OnToolbarChildViewAdded;
                    lastPage.PropertyChanged -= LastPage_PropertyChanged;
                }
            }
        }
        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            if (child.GetType() == typeof(Android.Support.V7.Widget.Toolbar))
            {
                var lastPage = Element?.Navigation?.NavigationStack?.Last();

                /*if (_toolbar !=null)
                {
                    _toolbar.ChildViewAdded -= OnToolbarChildViewAdded;
                    var lPage = Element?.Navigation?.NavigationStack?.Last();
                    lPage.PropertyChanged -= LastPage_PropertyChanged;
                }*/

                _toolbar = (Android.Support.V7.Widget.Toolbar)child;
                _originalToolbarBackground = _toolbar.Background;

                var originalContent = (Forms.Context as Activity)?.Window?.DecorView?.FindViewById<FrameLayout>(Window.IdAndroidContent);
                if (originalContent != null)
                {
                    _originalWindowContent =originalContent.Foreground;
                }

                _parentLayout = new Android.Widget.FrameLayout(_toolbar.Context)
                {
                    LayoutParameters = new Android.Widget.FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent)
                };

                //Create custom title view layout
                _titleViewLayout = new Android.Widget.LinearLayout(_parentLayout.Context)
                {
                    Orientation = Android.Widget.Orientation.Vertical,
                    LayoutParameters = new Android.Widget.FrameLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent)
                };
 
                //Create custom title text view
                _titleTextView = new TextView(_parentLayout.Context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent)
                };
              
                //Create custom subtitle text view
                _subTitleTextView = new TextView(_parentLayout.Context)
                {
                    LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent)    
                };

                //Add title/subtitle to title view layout
                _titleViewLayout.AddView(_titleTextView);
                _titleViewLayout.AddView(_subTitleTextView);

                //Add title view layout to main layout
                _parentLayout.AddView(_titleViewLayout);

                //Add main layout to toolbar
                _toolbar.AddView(_parentLayout);

                _toolbar.ChildViewAdded += OnToolbarChildViewAdded;

              
                

                lastPage.PropertyChanged += LastPage_PropertyChanged;


            }
        }

        void SetupToolbarCustomization(Page lastPage)
        {
   
            if (lastPage != null && _titleViewLayout != null)
            {
                UpdateTitleViewLayout(lastPage, _titleViewLayout, _titleTextView, _subTitleTextView, _originalDrawable);

                UpdateToolbarTitle(lastPage, _titleTextView,_subTitleTextView, _originalFont, _originalColorStateList);

                UpdateToolbarStyle(_toolbar, lastPage, Forms.Context as Activity,_originalToolbarBackground, _originalWindowContent);

            }
        }


        
        #region Title View Layout
        void UpdateTitleViewLayout(Page lastPage, Android.Widget.LinearLayout titleViewLayout, Android.Widget.TextView titleTextView, Android.Widget.TextView subTitleTextView, Android.Graphics.Drawables.Drawable defaultBackground)
        {

                UpdateTitleViewLayoutAlignment(titleViewLayout, titleTextView, subTitleTextView, CustomNavigationPage.GetTitlePosition(lastPage));

                if (!string.IsNullOrEmpty(CustomNavigationPage.GetTitleBackground(lastPage)))
                {
                    UpdateTitleViewLayoutBackground(titleViewLayout, CustomNavigationPage.GetTitleBackground(lastPage), defaultBackground);

                }
                else
                {
                    _titleViewLayout?.SetBackground(CreateShape(ShapeType.Rectangle, (int)CustomNavigationPage.GetTitleBorderWidth(lastPage), (int)CustomNavigationPage.GetTitleBorderCornerRadius(lastPage), CustomNavigationPage.GetTitleFillColor(lastPage), CustomNavigationPage.GetTitleBorderColor(lastPage)));
                }

                UpdateTitleViewLayoutMargin(titleViewLayout, CustomNavigationPage.GetTitleMargin(lastPage));

                UpdateTitleViewLayoutPadding(titleViewLayout, CustomNavigationPage.GetTitlePadding(lastPage));


        }

            void UpdateTitleViewLayoutAlignment(LinearLayout titleViewLayout, Android.Widget.TextView titleTextView, Android.Widget.TextView subTitleTextView, CustomNavigationPage.TitleAlignment alignment)
            {
                var titleViewParams = titleViewLayout.LayoutParameters as Android.Widget.FrameLayout.LayoutParams;
                var titleTextViewParams = titleTextView.LayoutParameters as LinearLayout.LayoutParams;
                var subTitleTextViewParams = subTitleTextView.LayoutParameters as LinearLayout.LayoutParams;
            
                switch (alignment)
                {
                    case CustomNavigationPage.TitleAlignment.Start:
                        titleViewParams.Gravity = GravityFlags.Start | GravityFlags.CenterVertical;
                        titleTextViewParams.Gravity = GravityFlags.Start;
                        subTitleTextViewParams.Gravity = GravityFlags.Start;

                        break;
                    case CustomNavigationPage.TitleAlignment.Center:

                        titleViewParams.Gravity = GravityFlags.Center;
                        titleTextViewParams.Gravity = GravityFlags.Center;
                        subTitleTextViewParams.Gravity = GravityFlags.Center;
                        break;
                    case CustomNavigationPage.TitleAlignment.End:
                        titleViewParams.Gravity = GravityFlags.End | GravityFlags.CenterVertical;
                        titleTextViewParams.Gravity = GravityFlags.End;
                        subTitleTextViewParams.Gravity = GravityFlags.End;
                        break;

                }

           
               titleViewLayout.LayoutParameters = titleViewParams;
            }
            void UpdateTitleViewLayoutBackground(LinearLayout titleViewLayout, string backgroundResource, Android.Graphics.Drawables.Drawable defaultBackground)
            {

                if (!string.IsNullOrEmpty(backgroundResource))
                {
                    titleViewLayout?.SetBackgroundResource(this.Context.Resources.GetIdentifier(backgroundResource, "drawable", Android.App.Application.Context.PackageName));
                }
                else
                {
                    titleViewLayout?.SetBackground(defaultBackground);
                }
            }
            void UpdateTitleViewLayoutPadding(LinearLayout titleViewLayout, Thickness padding)
            {
                titleViewLayout?.SetPadding((int)padding.Left, (int)padding.Top, (int)padding.Right, (int)padding.Bottom);
            }

            void UpdateTitleViewLayoutMargin(LinearLayout titleViewLayout, Thickness margin)
            {
                var titleViewParams = titleViewLayout.LayoutParameters as Android.Widget.FrameLayout.LayoutParams;

                titleViewParams?.SetMargins((int)margin.Left, (int)margin.Top, (int)margin.Right, (int)margin.Bottom);
                titleViewLayout.LayoutParameters = titleViewParams;
            }
        #endregion
        #region Toolbar 
            void UpdateToolbarStyle(Android.Support.V7.Widget.Toolbar toolbar, Page lastPage, Activity activity, Android.Graphics.Drawables.Drawable defaultBackground, Android.Graphics.Drawables.Drawable windowContent)
            {

                UpdateToolbarBackground(toolbar, lastPage, activity, defaultBackground);
                UpdateToolbarShadow(toolbar, CustomNavigationPage.GetHasShadow(lastPage), activity, windowContent);



            }
            void UpdateToolbarBackground(Android.Support.V7.Widget.Toolbar toolbar, Page lastPage, Activity activity, Android.Graphics.Drawables.Drawable defaultBackground)
            {
            
                if (string.IsNullOrEmpty(CustomNavigationPage.GetBarBackground(lastPage)) && CustomNavigationPage.GetGradientColors(lastPage) == null)
                {
                
                    toolbar.SetBackground(defaultBackground);
                }
                else
                {
                    if (!string.IsNullOrEmpty(CustomNavigationPage.GetBarBackground(lastPage)))
                    {
                   
                        toolbar.SetBackgroundResource(this.Context.Resources.GetIdentifier(CustomNavigationPage.GetBarBackground(lastPage), "drawable", Android.App.Application.Context.PackageName));

                    }

                    if (CustomNavigationPage.GetGradientColors(lastPage) != null)
                    {
                        var colors = CustomNavigationPage.GetGradientColors(lastPage);
                        var direction = GradientDrawable.Orientation.TopBottom;
                        switch (CustomNavigationPage.GetGradientDirection(lastPage))
                        {
                            case CustomNavigationPage.GradientDirection.BottomToTop:
                                direction = GradientDrawable.Orientation.BottomTop;
                                break;
                            case CustomNavigationPage.GradientDirection.RightToLeft:
                                direction = GradientDrawable.Orientation.RightLeft;
                                break;
                            case CustomNavigationPage.GradientDirection.LeftToRight:
                                direction = GradientDrawable.Orientation.LeftRight;
                                break;
                        }

                        GradientDrawable gradient = new GradientDrawable(direction, new int[] { colors.Item1.ToAndroid().ToArgb(), colors.Item2.ToAndroid().ToArgb() });
                        gradient.SetCornerRadius(0f);
                        if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.JellyBean)
                        {
                            toolbar.SetBackground(gradient);
                        }
                        else
                        {
                            toolbar.SetBackgroundDrawable(gradient);
                        }


                    }
                }
                toolbar.Background.SetAlpha((int)(CustomNavigationPage.GetBarBackgroundOpacity(lastPage) * 255));
              
            }

            void UpdateToolbarShadow(Android.Support.V7.Widget.Toolbar toolbar, bool hasShadow, Activity activity, Android.Graphics.Drawables.Drawable windowContent)
            {
                var androidContent = activity?.Window?.DecorView?.FindViewById<FrameLayout>(Window.IdAndroidContent);
                if (androidContent != null)
                {
                    if (hasShadow && activity != null)
                    {

                        GradientDrawable shadowGradient = new GradientDrawable(GradientDrawable.Orientation.RightLeft, new int[] { Android.Graphics.Color.Transparent.ToArgb(), Android.Graphics.Color.Gray.ToArgb() });
                        shadowGradient.SetCornerRadius(0f);


                        androidContent.Foreground = shadowGradient;

                        toolbar.Elevation = 4;
                    }
                    else
                    {

                        androidContent.Foreground = windowContent;

                        toolbar.Elevation = 0;
                    }
                }
                
            }
        #endregion
        #region Title TextView
        void UpdateToolbarTitle(Page lastPage, Android.Widget.TextView titleTextView, Android.Widget.TextView subTitleTextView, Typeface originalFont, ColorStateList defaultColorStateList)
        {
            //Check support for CustomPage 
            if (lastPage is CustomPage)
            {
                var cPage = lastPage as CustomPage;

                //Update main title formatted text
                UpdateFormattedTitleText(titleTextView, cPage.FormattedTitle, lastPage.Title);

                //Update subtitle text view
                UpdateToolbarSubtitle(cPage, subTitleTextView, originalFont, defaultColorStateList);

            }
            else
            {
                subTitleTextView.TextFormatted = new Java.Lang.String("");
                subTitleTextView.Text = string.Empty;
                subTitleTextView.Visibility = ViewStates.Gone;

                //Update main title text
                UpdateTitleText(titleTextView, lastPage.Title);
            }

            //Update main title color
            UpdateToolbarTextColor(titleTextView, CustomNavigationPage.GetTitleColor(lastPage), defaultColorStateList);

            //Update main title font
            UpdateToolbarTextFont(titleTextView, CustomNavigationPage.GetTitleFont(lastPage), originalFont);

        }
        void UpdateFormattedTitleText(Android.Widget.TextView titleTextView, FormattedString formattedString, string defaulTitle)
        {
            if (formattedString != null && formattedString.Spans.Count > 0)
            {
                titleTextView.TextFormatted = formattedString.ToAttributed(Font.Default, Xamarin.Forms.Color.Default, titleTextView);
            }
            else
            {
                //Update if not formatted text then update with normal title text
                UpdateTitleText(titleTextView, defaulTitle);
            }

        }
        void UpdateTitleText(Android.Widget.TextView titleTextView, string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                titleTextView.Text = text;
            }
            else
            {
                titleTextView.Text = string.Empty;
                titleTextView.TextFormatted = new Java.Lang.String("");
            }
        }

        #endregion
        #region Subtitle TextView
        void UpdateToolbarSubtitle(CustomPage cPage, Android.Widget.TextView subTitleTextView, Typeface originalFont, ColorStateList defaultColorStateList)
            {
                ClearTextView(subTitleTextView, true);

                if (cPage.FormattedSubtitle != null && cPage.FormattedSubtitle.Spans.Count > 0)
                {
                    subTitleTextView.TextFormatted = cPage.FormattedSubtitle.ToAttributed(Font.Default, Xamarin.Forms.Color.Default, _subTitleTextView);

                    subTitleTextView.Visibility = ViewStates.Visible;
                }
                else if (!string.IsNullOrEmpty(cPage.Subtitle))
                {
                    UpdateToolbarTextColor(subTitleTextView, CustomNavigationPage.GetSubtitleColor(cPage), _originalColorStateList);
                    UpdateToolbarTextFont(subTitleTextView, CustomNavigationPage.GetSubtitleFont(cPage), _originalFont);

                    subTitleTextView.Text = cPage.Subtitle;
                    subTitleTextView.Visibility = ViewStates.Visible;
                }
            }
        #endregion
        #region General TextView
        void UpdateToolbarTextColor(Android.Widget.TextView textView, Xamarin.Forms.Color? titleColor, ColorStateList defaultColorStateList)
            {
                if (titleColor != null)
                {
                    textView.SetTextColor(titleColor?.ToAndroid() ?? Android.Graphics.Color.White);
                }
                else
                {
                    textView.SetTextColor(defaultColorStateList);
                }
            }
            void UpdateToolbarTextFont(Android.Widget.TextView textView, Font customFont, Typeface originalFont)
            {
                if (customFont != null)
                {
                    textView.Typeface =customFont.ToTypeface();

                    float tValue = customFont.ToScaledPixel();
                    textView.SetTextSize(ComplexUnitType.Sp, tValue);
            }
                else
                {
                    textView.Typeface = originalFont;
                }
            }
            void ClearTextView(TextView textView, bool hide)
            {
                textView.TextFormatted = new Java.Lang.String("");
                textView.Text = string.Empty;
                if (hide)
                {
                    textView.Visibility = ViewStates.Gone;
                }

            }
        #endregion

        Drawable CreateShape(ShapeType type,int strokeWidth,int cornerRadius,Xamarin.Forms.Color? fillColor,Xamarin.Forms.Color? strokeColor)
        {
            GradientDrawable shape = new GradientDrawable();
            shape.SetShape(type);
            if(fillColor !=null)
            {
                shape.SetColor(fillColor?.ToAndroid() ?? Xamarin.Forms.Color.Transparent.ToAndroid());
            }

            if (strokeColor != null)
            {
                shape.SetStroke(strokeWidth, strokeColor?.ToAndroid()??Xamarin.Forms.Color.Transparent.ToAndroid());
            }

           
            shape.SetCornerRadius(cornerRadius);

            return shape;
        }

        
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
        }
        private void OnToolbarChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            var view = e.Child.GetType();
     
            if (e.Child.GetType() == typeof(Android.Widget.TextView))
            {
               
                var textView = (Android.Widget.TextView)e.Child;
                textView.Visibility = ViewStates.Gone;
                _originalDrawable = textView.Background;
                _originalFont = textView.Typeface;
                _originalColorStateList = textView.TextColors;
                
                    var lastPage = Element?.Navigation?.NavigationStack?.Last();
                    SetupToolbarCustomization(lastPage);
                  


            }
        }
       
    }
}