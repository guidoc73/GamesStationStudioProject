using System;
using System.Collections.Generic;

public class EventBus
{
    private static Dictionary<Type, Action<object>> eventDictionary = new Dictionary<Type, Action<object>>();

    private static EventBus eventBus;

    public static EventBus Instance
    {
        get
        {
            if (eventBus == null)
            {
                eventBus = new EventBus();
            }

            return eventBus;
        }
    }

    public void Subscribe<T>(Action listener) where T : ICustomEvents
    {
        Action<object> voidListener = obj => listener();

        if (eventDictionary.TryGetValue(typeof(T), out Action<object> thisEvent))
        {
            thisEvent += voidListener;
            eventDictionary[typeof(T)] = thisEvent;
        }
        else
        {
            thisEvent += voidListener;
            eventDictionary.Add(typeof(T), thisEvent);
        }
    }

    public void Subscribe<T>(Action<object> listener) where T : ICustomEvents
    {
        if (eventDictionary.TryGetValue(typeof(T), out Action<object> thisEvent))
        {
            thisEvent += listener;
            eventDictionary[typeof(T)] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            eventDictionary.Add(typeof(T), thisEvent);
        }
    }

    public void Unsubscribe<T>(Action listener) where T : ICustomEvents
    {
        Action<object> voidListener = obj => listener();

        if (eventDictionary.TryGetValue(typeof(T), out Action<object> thisEvent))
        {
            thisEvent -= voidListener;
            eventDictionary[typeof(T)] = thisEvent;
        }
    }

    public void Unsubscribe<T>(Action<object> listener) where T : ICustomEvents
    {
        if (eventDictionary.TryGetValue(typeof(T), out Action<object> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[typeof(T)] = thisEvent;
        }
    }

    public void Publish<T>() where T : ICustomEvents
    {
        Publish<T>(null);
    }

    public void Publish<T>(object eventData) where T : ICustomEvents
    {
        if (eventDictionary.TryGetValue(typeof(T), out Action<object> thisEvent))
        {
            thisEvent.Invoke(eventData);
        }
    }


    public void UnsubscribeAll()
    {
        eventDictionary.Clear();
    }
}
