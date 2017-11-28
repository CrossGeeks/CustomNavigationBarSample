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
    public partial class GradientTitlePage : ContentPage
    {
      
        public GradientTitlePage()
        {
            Title = "My Title";
            CustomNavigationPage.SetTitleMargin(this, new Thickness(5, 5, 5, 5));
            InitializeComponent();
           
            startColorPicker.ItemsSource = App.Colors;
            endColorPicker.ItemsSource = App.Colors;
            titleColorPicker.ItemsSource = App.Colors;

            titleColorPicker.SelectedIndex = App.Colors.Count - 2;
            startColorPicker.SelectedIndex = 1;
            endColorPicker.SelectedIndex = App.Colors.Count - 1;
            gradientDirectionPicker.SelectedIndex = 0;
            
        }

        private void ColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (startColorPicker.SelectedIndex != -1 && endColorPicker.SelectedIndex!=-1)
            {
                var startColor = App.Colors.FirstOrDefault(n => n.Item1 == startColorPicker.Items[startColorPicker.SelectedIndex]).Item2;
                var endColor = App.Colors.FirstOrDefault(n => n.Item1 == endColorPicker.Items[endColorPicker.SelectedIndex]).Item2;
                CustomNavigationPage.SetGradientColors(this, new Tuple<Color, Color>(startColor, endColor));
            }
        }


        private void GradientDirectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.Items[selectedIndex])
                {
                    case "Top to Bottom":
                        CustomNavigationPage.SetGradientDirection(this, CustomNavigationPage.GradientDirection.TopToBottom);
                        break;
                    case "Right to Left":
                        CustomNavigationPage.SetGradientDirection(this, CustomNavigationPage.GradientDirection.RightToLeft);
                        break;
                    case "Left to Right":
                        CustomNavigationPage.SetGradientDirection(this, CustomNavigationPage.GradientDirection.LeftToRight);
                        break;
                    case "Bottom to Top":
                        CustomNavigationPage.SetGradientDirection(this, CustomNavigationPage.GradientDirection.BottomToTop);
                        break;
                }
            }
        }

        private void TitleColorPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
               
                   var titleColor = App.Colors.FirstOrDefault(n => n.Item1 == picker.Items[selectedIndex]).Item2;
                   CustomNavigationPage.SetTitleColor(this, titleColor);
            }
            
        }
    }
}