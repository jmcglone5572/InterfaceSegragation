using System;
using Contracts;

namespace ClassImplementations
{
    public class EventPublisher<TEntity> : IEventPublisher
    {
        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent
        {
        }
    }
}
