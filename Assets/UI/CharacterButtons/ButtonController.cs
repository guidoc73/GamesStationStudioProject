public class ButtonController
{
    private CustomEvents customEvent;

    public ButtonController(CustomEvents customEvent)
    {
        this.customEvent = customEvent;
    }

    public void StartAction()
    {
        EventBus.Instance.Publish(customEvent, true);
    }

    public void StopAction()
    {
        EventBus.Instance.Publish(customEvent, false);
    }
}
