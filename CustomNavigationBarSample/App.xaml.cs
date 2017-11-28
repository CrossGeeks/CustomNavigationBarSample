using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CustomNavigationBarSample
{
    public partial class App : Application
    {
        public static List<Tuple<string, Color>> Colors = new List<Tuple<string, Color>>
        {
            new Tuple<string, Color>("Default", Color.Default),
            new Tuple<string, Color>("Amber", Color.FromHex("#FFC107")),
            new Tuple<string, Color>("Black", Color.FromHex("#212121")),
            new Tuple<string, Color>("Blue", Color.FromHex("#2196F3")),
            new Tuple<string, Color>("Blue Grey", Color.FromHex("#607D8B")),
            new Tuple<string, Color>("Brown", Color.FromHex("#795548")),
            new Tuple<string, Color>("Cyan", Color.FromHex("#00BCD4")),
            new Tuple<string, Color>("Dark Orange", Color.FromHex("#FF5722")),
            new Tuple<string, Color>("Dark Purple", Color.FromHex("#673AB7")),
            new Tuple<string, Color>("Green", Color.FromHex("#4CAF50")),
            new Tuple<string, Color>("Grey", Color.FromHex("#9E9E9E")),
            new Tuple<string, Color>("Indigo", Color.FromHex("#3F51B5")),
            new Tuple<string, Color>("Light Blue", Color.FromHex("#02A8F3")),
            new Tuple<string, Color>("Light Green", Color.FromHex("#8AC249")),
            new Tuple<string, Color>("Lime", Color.FromHex("#CDDC39")),
            new Tuple<string, Color>("Orange", Color.FromHex("#FF9800")),
            new Tuple<string, Color>("Pink", Color.FromHex("#E91E63")),
            new Tuple<string, Color>("Purple", Color.FromHex("#94499D")),
            new Tuple<string, Color>("Red", Color.FromHex("#D32F2F")),
            new Tuple<string, Color>("Teal", Color.FromHex("#009587")),
            new Tuple<string, Color>("White", Color.FromHex("#FFFFFF")),
            new Tuple<string, Color>("Yellow", Color.FromHex("#FFEB3B")),
        };
        public App()
        {
            InitializeComponent();

            MainPage = new CustomNavigationPage(new CustomNavigationBarSample.MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
