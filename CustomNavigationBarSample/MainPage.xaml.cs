using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomNavigationBarSample
{
    public partial class MainPage : CustomPage
    {
        IList<string> options  = new List<string>()
        {
            "Title Font/Position",
            "Formatted Title",
            "Gradient Background",
            "Title Customization",
            "Image Title",
            "Bar Image Background"
        };
     
        public MainPage()
        {
            CustomNavigationPage.SetTitleMargin(this, new Thickness(0, 0, 5, 0));
            CustomNavigationPage.SetTitleColor(this, Color.Gray);
            CustomNavigationPage.SetSubtitleColor(this, Color.ForestGreen);
            CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.End);
            CustomNavigationPage.SetSubtitleFont(this, Font.SystemFontOfSize(NamedSize.Micro));
            InitializeComponent();
            listView.ItemsSource = options;
        }

        private async void ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = sender as ListView;
            switch(e.SelectedItem)
            {
                case "Title Font/Position":
                    await Navigation.PushAsync(new TitlePositionPage());
                    break;
                case "Formatted Title":
                    await Navigation.PushAsync(new FormattedTitlePage());
                    break;
                case "Gradient Background":
                    await Navigation.PushAsync(new GradientTitlePage());
                    break;
                case "Title Customization":
                    await Navigation.PushAsync(new TitleBorderPage());
                    break;
                case "Image Title":
                    await Navigation.PushAsync(new TitleImagePage());
                    break;
                case "Bar Image Background":
                    await Navigation.PushAsync(new BarBackgroundPage());
                    break;
            }
            listView.SelectedItem = null;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            CustomNavigationPage.SetHasShadow(this, e.Value);
        }
    }
}
