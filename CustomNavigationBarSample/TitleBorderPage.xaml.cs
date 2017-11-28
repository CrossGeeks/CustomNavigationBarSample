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
    public partial class TitleBorderPage : ContentPage
    {
        public TitleBorderPage()
        {
            Title = "Bordered Title";


            InitializeComponent();
            titleEntry.Text = Title;
            titleBorderColorPicker.ItemsSource = App.Colors;
            titleFillColorPicker.ItemsSource = App.Colors;

            titleBorderColorPicker.SelectedIndex = 5;

            titleFillColorPicker.SelectedIndex = 10;
            CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Center);
            
        }

        private void BorderRadiuSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CustomNavigationPage.SetTitleBorderCornerRadius(this, (float)e.NewValue);
        }

        private void BorderWidthSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CustomNavigationPage.SetTitleBorderWidth(this, (float)e.NewValue);
        }

        private void TitlePaddingSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
          
            CustomNavigationPage.SetTitlePadding(this, new Thickness((float)e.NewValue, (float)e.NewValue, (float)e.NewValue, (float)e.NewValue));
        }
        
        private void TitleMarginSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CustomNavigationPage.SetTitleMargin(this, new Thickness((float)e.NewValue, (float)e.NewValue, (float)e.NewValue, (float)e.NewValue));

        }

        private void TitleFillColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {

                var titleColor = App.Colors.FirstOrDefault(n => n.Item1 == picker.Items[selectedIndex]).Item2;
                CustomNavigationPage.SetTitleFillColor(this, titleColor);
            }
        }

        private void TitleBorderColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {

                var titleColor = App.Colors.FirstOrDefault(n => n.Item1 == picker.Items[selectedIndex]).Item2;
                CustomNavigationPage.SetTitleBorderColor(this, titleColor);
            }
        }

        private void TitleEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Title = e.NewTextValue;
        }
    }
}