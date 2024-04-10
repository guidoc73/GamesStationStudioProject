using System;

public interface IEventBus
{
    void Subscribe<T>(Action listener) where T : ICustomEvents;
    void Subscribe<T>(Action<object> listener) where T : ICustomEvents;

    void Unsubscribe<T>(Action listener) where T : ICustomEvents;
    void Unsubscribe<T>(Action<object> listener) where T : ICustomEvents;

    void Publish<T>() where T : ICustomEvents;
    void Publish<T>(object eventData) where T : ICustomEvents;
    void UnsubscribeAll();

}
