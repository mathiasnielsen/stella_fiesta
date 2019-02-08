using StellaFiesta.Client.iOS;
using StellaFiesta.Client.Tools;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PlaygroundView), typeof(PlaygroundPageRenderer))]
namespace StellaFiesta.Client.iOS
{
    public class PlaygroundPageRenderer : PageRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (NavigationController != null && NavigationController.NavigationBar != null)
            {
                NavigationController.NavigationBar.Translucent = true;
            }
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
            }

            if (e.NewElement != null)
            {
            }
        }
    }
}
