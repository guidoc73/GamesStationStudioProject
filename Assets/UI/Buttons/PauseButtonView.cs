using UnityEngine.EventSystems;

public class PauseButtonView : ButtonView
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _controller.ButtonPressed<PauseButtonPressedEvent>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _controller.ButtonReleased<PauseButtonReleasedEvent>();
    }
}
