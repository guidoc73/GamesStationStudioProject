using UnityEngine.EventSystems;

public class LeftButtonView : ButtonView
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _controller.ButtonPressed<WalkLeftButtonPressedEvent>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _controller.ButtonReleased<WalkLeftButtonReleasedEvent>();
    }
}
