using StellaFiesta.Client.CoreStandard;

namespace StellaFiesta.Client.Core
{
    public class AboutViewModel : BindableViewModelBase
    {
        public AboutViewModel(IConnectivityService connectivityService)
            : base(connectivityService)
        {
        }

        public string Title => "About the Stella app";

        public string AppDescription => GetAppDescription();

        private string GetAppDescription()
        {
            var description = string.Empty;

            description += "This application gives you an amazing chance to borrow the most beautiful car in the worl.";
            description += System.Environment.NewLine + System.Environment.NewLine;
            description += "You simply need to book it through the calendar, and pick it up where ever it is.";
            description += System.Environment.NewLine + System.Environment.NewLine;
            description += "Hope you will enjoy.";

            return description;
        }
    }
}
