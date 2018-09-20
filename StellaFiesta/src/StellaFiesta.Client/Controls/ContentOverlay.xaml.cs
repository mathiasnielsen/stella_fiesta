using Xamarin.Forms;

namespace StellaFiesta.Client.Controls
{
    // https://xamarinhelp.com/xamarin-forms-page-templates/
    public partial class ContentOverlay : ContentView
    {
        public ContentOverlay()
        {
            InitializeComponent();

            Root.BackgroundColor = Color.Gray.MultiplyAlpha(0.1);
        }
    }
}
