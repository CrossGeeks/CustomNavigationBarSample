using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static CustomNavigationBarSample.CustomNavigationPage;

namespace CustomNavigationBarSample
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormattedTitlePage : CustomPage
    {
        public FormattedTitlePage()
        {
            this.FormattedTitle = new FormattedString();
            this.FormattedTitle.Spans.Add(new Span()
            {
                Text = "My ",
                FontSize = 14,
                ForegroundColor = Color.Orange,
            });

            this.FormattedTitle.Spans.Add(new Span()
            {
                Text = "Awesome ",
                FontSize = 18,
                ForegroundColor = Color.Navy,
            });

            this.FormattedTitle.Spans.Add(new Span()
            {
                Text = "Title",
                FontSize = 16,
                ForegroundColor = Color.LightGreen,
            });

            this.FormattedSubtitle = new FormattedString();
            this.FormattedSubtitle.Spans.Add(new Span()
            {
                Text = "Just ",
                FontSize = 10,
                ForegroundColor = Color.Brown,
            });

            this.FormattedSubtitle.Spans.Add(new Span()
            {
                Text = "a nice ",
                FontSize = 14,
                ForegroundColor = Color.DarkSalmon,
            });

            this.FormattedSubtitle.Spans.Add(new Span()
            {
                Text = "Subtitle",
                FontSize = 12,
                ForegroundColor = Color.Purple,
            });
            CustomNavigationPage.SetTitlePosition(this, TitleAlignment.Center);

            InitializeComponent();

        
        }
    }
}