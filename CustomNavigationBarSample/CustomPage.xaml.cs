using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomNavigationBarSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomPage : ContentPage
    {

        public static readonly BindableProperty FormattedTitleProperty = BindableProperty.Create(nameof(FormattedTitle),typeof(FormattedString),typeof(CustomPage),null);
              
        public FormattedString FormattedTitle
        {
            get { return (FormattedString)GetValue(FormattedTitleProperty); }
            set
            {
                SetValue(FormattedTitleProperty, value);
            }
        }

        public static readonly BindableProperty FormattedSubtitleProperty = BindableProperty.Create(nameof(FormattedSubtitle),typeof(FormattedString), typeof(CustomPage), null);
           
        public FormattedString FormattedSubtitle
        {
            get { return (FormattedString)GetValue(FormattedSubtitleProperty); }
            set
            {
                SetValue(FormattedSubtitleProperty, value);
            }
        }

        public static readonly BindableProperty SubtitleProperty = BindableProperty.Create(nameof(Subtitle),typeof(string),typeof(CustomPage),null);
        
        
        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set
            {
                SetValue(SubtitleProperty, value);
            }
        }


        public CustomPage()
        {
            InitializeComponent();
        }
    }
}
