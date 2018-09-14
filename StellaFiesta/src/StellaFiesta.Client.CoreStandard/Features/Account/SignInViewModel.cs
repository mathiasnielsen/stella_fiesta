using System.Threading.Tasks;
using StellaFiesta.Client.Core;
using StellaFiesta.Models;

namespace StellaFiesta.Client.CoreStandard
{
    public class SignInViewModel : BindableViewModelBase
    {
        private FacebookProfile _facebookProfile;

        public FacebookProfile FacebookProfile
        {
            get { return _facebookProfile; }
            set { Set(ref _facebookProfile, value); }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookServices = new FacebookServices();
            FacebookProfile = await facebookServices.GetFacebookProfileAsync(accessToken);
        }
    }
}
