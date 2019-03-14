using System.Threading.Tasks;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IAuthenticationService
    {
        bool IsLoggedIn { get; }

        Task<UserProfile> GetProfileAsync(int imageSize = 100);

        void SignOut();
    }
}
