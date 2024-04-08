public class ButtonController
{
    private CustomEvents customEvent;

    public ButtonController(CustomEvents customEvent)
    {
        this.customEvent = customEvent;
    }

    public void StartAction()
    {
        EventBus<bool>.Instance.Publish(customEvent, true);
    }

    public void StopAction()
    {
        EventBus<bool>.Instance.Publish(customEvent, false);
    }
}
