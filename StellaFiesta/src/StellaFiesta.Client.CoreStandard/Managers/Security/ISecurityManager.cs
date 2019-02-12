namespace StellaFiesta.Client.CoreStandard
{
    public interface ISecurityManager
    {
        bool HasBookingAccess { get; }

        bool GiveBookingPermissionIfPasswordIsCorrect(string userInput);
    }
}
