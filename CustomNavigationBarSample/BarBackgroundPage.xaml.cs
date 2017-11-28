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
    public partial class BarBackgroundPage : ContentPage
    {
        public BarBackgroundPage()
        {
            InitializeComponent();
            Title = "Monkey Title";
            opacitySlider.Value = 0.6f;
            CustomNavigationPage.SetTitleColor(this,Color.Navy);
            CustomNavigationPage.SetBarBackground(this, Device.RuntimePlatform == Device.iOS ? "monkeybackground.jpg": "monkeybackground");
        }

        private void OpacitySlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            CustomNavigationPage.SetBarBackgroundOpacity(this, (float)e.NewValue);
        }
    }
}