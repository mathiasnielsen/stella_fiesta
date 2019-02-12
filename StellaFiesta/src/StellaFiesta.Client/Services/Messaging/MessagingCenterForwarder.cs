using System;
using StellaFiesta.Client.CoreStandard;
using Xamarin.Forms;

namespace StellaFiesta.Client
{
    public class MessagingCenterForwarder : IMessagingCenterForwarder
    {
        public void Subscribe(object subscriber, Action<Message> action)
        {
            MessagingCenter.Subscribe(this, "", action);
        }

        public void Publish(object subscriber, Message message)
        {
            MessagingCenter.Send(message, "");
        }
    }
}
