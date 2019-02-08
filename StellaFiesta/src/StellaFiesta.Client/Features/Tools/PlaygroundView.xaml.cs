using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Tools
{
    public abstract class PlaygroundViewBase : BindableViewBase<PlaygroundViewModel>
    {
    }

    public partial class PlaygroundView : PlaygroundViewBase
    {
        public PlaygroundView()
        {
            InitializeComponent();
        }
    }
}
