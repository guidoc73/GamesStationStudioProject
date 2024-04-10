using UnityEngine.EventSystems;

public class RestartButtonView : ButtonView
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _controller.ButtonPressed<RestartButtonPressedEvent>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _controller.ButtonReleased<RestartButtonReleasedEvent>();
    }
}