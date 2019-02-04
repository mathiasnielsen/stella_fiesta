namespace StellaFiesta.Client.CoreStandard
{
    public interface IToastService
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
