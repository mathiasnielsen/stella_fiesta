using StellaFiesta.Client.Enums;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class TransitionNavigationPage : NavigationPage
    {
        public static readonly BindableProperty TransitionTypeProperty =
             BindableProperty.Create(
                nameof(TransitionType),
                typeof(TransitionType),
                typeof(TransitionNavigationPage),
                TransitionType.SlideFromLeft);

        public TransitionType TransitionType
        {
            get { return (TransitionType)GetValue(TransitionTypeProperty); }
            set { SetValue(TransitionTypeProperty, value); }
        }

        public TransitionNavigationPage()
            : base()
        {
        }

        public TransitionNavigationPage(Page root)
            : base(root)
        {
        }
    }
}
