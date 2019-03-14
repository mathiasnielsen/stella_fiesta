using System;
using Plugin.LocalNotifications;
using StellaFiesta.Client.CoreStandard.Services;

namespace StellaFiesta.Client.Services
{
    /// <summary>
    /// Not implemented for Android yet. TODO: https://github.com/edsnider/localnotificationsplugin
    /// </summary>
    public class LocalNotificationService : ILocalNotificationService
    {
        public void ScheduleNotification(string title, string body, int id, DateTime timeToShowNotification)
        {
            CrossLocalNotifications.Current.Show(title, body, id, timeToShowNotification);
        }

        public void CancelNotification(int id)
        {
            CrossLocalNotifications.Current.Cancel(id);
        }
    }
}
