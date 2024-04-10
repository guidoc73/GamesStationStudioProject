using UnityEngine;

public class ButtonController
{
    public void ButtonPressed<T>() where T : ICustomEvents
    {
        EventBus.Instance.Publish<T>();
    }

    public void ButtonReleased<T>() where T : ICustomEvents
    {
        EventBus.Instance.Publish<T>();
    }
}
