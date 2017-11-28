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
    public partial class TitlePositionPage : CustomPage
    {
        public TitlePositionPage()
        {
            InitializeComponent();
            positionPicker.SelectedIndex = 0;
            fontSizePicker.SelectedIndex = 2;
        }

        private void PositionPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch(picker.Items[selectedIndex])
                {
                    case "Start":
                        CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Start);
                        break;
                    case "Center":
                        CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Center);
                        break;
                    case "End":
                        CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.End);
                        break;
                }
            }
        }

        private void FontSizePickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;

            if (selectedIndex != -1)
            {
                switch (picker.Items[selectedIndex])
                {
                    case "Micro":
                        CustomNavigationPage.SetTitleFont(this,Font.SystemFontOfSize(NamedSize.Micro));
                        break;
                    case "Small":
                        CustomNavigationPage.SetTitleFont(this, Font.SystemFontOfSize(NamedSize.Small));
                        break;
                    case "Medium":
                        CustomNavigationPage.SetTitleFont(this, Font.SystemFontOfSize(NamedSize.Medium));
                        break;
                    case "Large":
                        CustomNavigationPage.SetTitleFont(this, Font.SystemFontOfSize(NamedSize.Large));
                        break;
                }
            }
        }

        private void ShowSubtitle_Toggled(object sender, ToggledEventArgs e)
        {
            Subtitle = e.Value ? "My Subtitle" : string.Empty;
        }
    }

   
}