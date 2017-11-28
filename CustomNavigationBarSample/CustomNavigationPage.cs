using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomNavigationBarSample
{
    public class CustomNavigationPage : NavigationPage
    {
        public enum TitleAlignment
        {
            Start,
            Center,
            End
        }

        public enum GradientDirection
        {
             LeftToRight,
             RightToLeft,
             TopToBottom,
             BottomToTop
        }


        public static readonly BindableProperty TitlePositionProperty = BindableProperty.CreateAttached("TitlePosition", typeof(TitleAlignment), typeof(CustomNavigationPage), Device.RuntimePlatform == Device.iOS ? TitleAlignment.Center: TitleAlignment.Start);

        public static TitleAlignment GetTitlePosition(BindableObject view)
        {

            return (TitleAlignment)view.GetValue(TitlePositionProperty);
        }

        public static void SetTitlePosition(BindableObject view, TitleAlignment value)
        {
            view.SetValue(TitlePositionProperty, value);
        }


        public static readonly BindableProperty TitleBackgroundProperty = BindableProperty.CreateAttached("TitleBackground", typeof(string), typeof(CustomNavigationPage), string.Empty);

        public static string GetTitleBackground(BindableObject view)
        {

            return (string)view.GetValue(TitleBackgroundProperty);
        }

        public static void SetTitleBackground(BindableObject view, string value)
        {
            view.SetValue(TitleBackgroundProperty, value);
        }

        public static readonly BindableProperty TitleFontProperty = BindableProperty.CreateAttached("TitleFont", typeof(Font), typeof(CustomNavigationPage), Font.SystemFontOfSize(NamedSize.Medium));

        public static Font GetTitleFont(BindableObject view)
        {

            return (Font)view.GetValue(TitleFontProperty);
        }

        public static void SetTitleFont(BindableObject view, Font value)
        {
            view.SetValue(TitleFontProperty, value);
        }


        public static readonly BindableProperty TitlePaddingProperty = BindableProperty.CreateAttached("TitlePadding", typeof(Thickness), typeof(CustomNavigationPage), default(Thickness));

        public static Thickness GetTitlePadding(BindableObject view)
        {

            return (Thickness)view.GetValue(TitlePaddingProperty);
        }

        public static void SetTitlePadding(BindableObject view, Thickness value)
        {
            view.SetValue(TitlePaddingProperty, value);
        }



        public static readonly BindableProperty TitleMarginProperty = BindableProperty.CreateAttached("TitleMargin", typeof(Thickness), typeof(CustomNavigationPage), default(Thickness));

        public static Thickness GetTitleMargin(BindableObject view)
        {

            return (Thickness)view.GetValue(TitleMarginProperty);
        }

        public static void SetTitleMargin(BindableObject view, Thickness value)
        {
            view.SetValue(TitleMarginProperty, value);
        }


        public static readonly BindableProperty BarBackgroundProperty = BindableProperty.CreateAttached("BarBackground", typeof(string), typeof(CustomNavigationPage), string.Empty);

        public static string GetBarBackground(BindableObject view)
        {

            return (string)view.GetValue(BarBackgroundProperty);
        }

        public static void SetBarBackground(BindableObject view, string value)
        {
            view.SetValue(BarBackgroundProperty, value);
        }


        public static readonly BindableProperty GradientColorsProperty = BindableProperty.CreateAttached("GradientColors", typeof(Tuple<Color,Color>), typeof(CustomNavigationPage), null);

        public static Tuple<Color, Color> GetGradientColors(BindableObject view)
        {

            return (Tuple<Color, Color>)view.GetValue(GradientColorsProperty);
        }

        public static void SetGradientColors(BindableObject view, Tuple<Color, Color> value)
        {
            view.SetValue(GradientColorsProperty, value);
        }

        public static readonly BindableProperty GradientDirectionProperty = BindableProperty.CreateAttached("GradientDirection", typeof(GradientDirection), typeof(CustomNavigationPage), GradientDirection.TopToBottom);

        public static GradientDirection GetGradientDirection(BindableObject view)
        {

            return (GradientDirection)view.GetValue(GradientDirectionProperty);
        }

        public static void SetGradientDirection(BindableObject view, GradientDirection value)
        {
            view.SetValue(GradientDirectionProperty, value);
        }

        public static readonly BindableProperty SubtitleFontProperty = BindableProperty.CreateAttached("SubtitleFont", typeof(Font), typeof(CustomNavigationPage), Font.SystemFontOfSize(NamedSize.Small));

        public static Font GetSubtitleFont(BindableObject view)
        {

            return (Font)view.GetValue(SubtitleFontProperty);
        }

        public static void SetSubtitleFont(BindableObject view, Font value)
        {
            view.SetValue(SubtitleFontProperty, value);
        }

        public static readonly BindableProperty TitleColorProperty = BindableProperty.CreateAttached("TitleColor", typeof(Color?), typeof(CustomNavigationPage),null);

        public static Color? GetTitleColor(BindableObject view)
        {

            return (Color?)view.GetValue(TitleColorProperty);
        }

        public static void SetTitleColor(BindableObject view, Color? value)
        {
            view.SetValue(TitleColorProperty, value);
        }

        public static readonly BindableProperty SubtitleColorProperty = BindableProperty.CreateAttached("SubtitleColor", typeof(Color?), typeof(CustomNavigationPage), null);

        public static Color? GetSubtitleColor(BindableObject view)
        {

            return (Color?)view.GetValue(SubtitleColorProperty);
        }

        public static void SetSubtitleColor(BindableObject view, Color? value)
        {
            view.SetValue(SubtitleColorProperty, value);
        }


        public static readonly BindableProperty HasShadowProperty = BindableProperty.CreateAttached("HasShadow", typeof(bool), typeof(CustomNavigationPage), false);

        public static bool GetHasShadow(BindableObject view)
        {

            return (bool)view.GetValue(HasShadowProperty);
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }


        public static readonly BindableProperty TitleBorderCornerRadiusProperty = BindableProperty.CreateAttached("TitleBorderCornerRadius", typeof(float), typeof(CustomNavigationPage), 0.0f);

        public static float GetTitleBorderCornerRadius(BindableObject view)
        {

            return (float)view.GetValue(TitleBorderCornerRadiusProperty);
        }

        public static void SetTitleBorderCornerRadius(BindableObject view,float value)
        {
            view.SetValue(TitleBorderCornerRadiusProperty, value);
        }

        public static readonly BindableProperty TitleBorderColorProperty = BindableProperty.CreateAttached("TitleBorderColor", typeof(Color?), typeof(CustomNavigationPage), null);

        public static Color? GetTitleBorderColor(BindableObject view)
        {

            return (Color?)view.GetValue(TitleBorderColorProperty);
        }
        
        public static void SetTitleBorderColor(BindableObject view, Color? value)
        {
            view.SetValue(TitleBorderColorProperty, value);
        }

        public static readonly BindableProperty TitleFillColorProperty = BindableProperty.CreateAttached("TitleFillColor", typeof(Color?), typeof(CustomNavigationPage), null);

        public static Color? GetTitleFillColor(BindableObject view)
        {

            return (Color?)view.GetValue(TitleFillColorProperty);
        }

        public static void SetTitleFillColor(BindableObject view, Color? value)
        {
            view.SetValue(TitleFillColorProperty, value);
        }

        public static readonly BindableProperty TitleBorderWidthProperty = BindableProperty.CreateAttached("TitleBorderWidth", typeof(float), typeof(CustomNavigationPage), 0.0f);

        public static float GetTitleBorderWidth(BindableObject view)
        {

            return (float)view.GetValue(TitleBorderWidthProperty);
        }

        public static void SetTitleBorderWidth(BindableObject view, float value)
        {
            view.SetValue(TitleBorderWidthProperty, value);
        }

        public static readonly BindableProperty BarBackgroundOpacityProperty = BindableProperty.CreateAttached("BarBackgroundOpacity", typeof(float), typeof(CustomNavigationPage), 1.0f);

        public static float GetBarBackgroundOpacity(BindableObject view)
        {

            return (float)view.GetValue(BarBackgroundOpacityProperty);
        }

        public static void SetBarBackgroundOpacity(BindableObject view, float value)
        {
            view.SetValue(BarBackgroundOpacityProperty, value);
        }
        public CustomNavigationPage(Page page) : base(page)
        {
         
        }
    }
}
