using System;
using System.Collections.Generic;

public class EventBus<T>
{
    private static Dictionary<CustomEvents, Action<T>> eventDictionary  = new Dictionary<CustomEvents, Action<T>>();

    private static EventBus<T> eventBus;

    public static EventBus<T> Instance
    {
        get
        {
            if (eventBus == null)
            {
                eventBus = new EventBus<T>();
            }

            return eventBus;
        }
    }

    public void Subscribe(CustomEvents eventName, Action<T> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<T> thisEvent))
        {
            thisEvent += listener;
            eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void Unsubscribe(CustomEvents eventName, Action<T> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<T> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public void Publish(CustomEvents eventName, T value)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<T> thisEvent))
        {
            thisEvent.Invoke(value);
        }
    }
}
