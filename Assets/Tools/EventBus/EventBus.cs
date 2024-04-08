using System;
using System.Collections.Generic;

public class EventBus
{
    private static Dictionary<CustomEvents, Action> eventDictionary  = new Dictionary<CustomEvents, Action>();

    private static EventBus eventBus;

    public static EventBus Instance
    {
        get
        {
            if (eventBus != null)
            {
                eventBus = new EventBus();
            }

            return eventBus;
        }
    }

    public static void Subscribe(CustomEvents eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
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

    public static void Unsubscribe(CustomEvents eventName, Action listener)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent -= listener;
            eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(CustomEvents eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out Action thisEvent))
        {
            thisEvent.Invoke();
            
        }
    }
}
