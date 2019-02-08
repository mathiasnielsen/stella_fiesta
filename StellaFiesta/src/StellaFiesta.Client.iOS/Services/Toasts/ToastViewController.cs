using UIKit;

namespace StellaFiesta.Client.iOS
{
    public class ToastViewController : UIViewController
    {
        public ToastViewController()
        {
            EdgesForExtendedLayout = UIRectEdge.None;
        }

        public override bool PrefersStatusBarHidden()
        {
            return false;
        }
    }
}