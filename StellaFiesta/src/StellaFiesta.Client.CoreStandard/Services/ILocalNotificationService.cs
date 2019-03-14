using System;

namespace StellaFiesta.Client.CoreStandard.Services
{
    public interface ILocalNotificationService
    {
        void ScheduleNotification(string title, string body, int id, DateTime timeToShowNotification);

        void CancelNotification(int id);
    }
}
