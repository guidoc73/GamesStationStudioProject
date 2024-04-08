using System;
using System.Collections.Generic;

public class EventBus
{
    private static Dictionary<CustomEvents, Action<bool>> eventDictionary  = new Dictionary<CustomEvents, Action<bool>>();

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

    public void Subscribe(CustomEvents eventName, Action<bool> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<bool> thisEvent))
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

    public void Unsubscribe(CustomEvents eventName, Action<bool> listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<bool> thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public void Publish(CustomEvents eventName, bool value)
    {
        if (eventDictionary.TryGetValue(eventName, out Action<bool> thisEvent))
        {
            thisEvent.Invoke(value);
        }
    }
}
