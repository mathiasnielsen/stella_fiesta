using System;

namespace StellaFiesta.Client.CoreStandard
{
    public interface IMessagingCenterForwarder
    {
        void Subscribe(object subscriber, Action<Message> action);

        void Publish(object subscriber, Message message);
    }
}
