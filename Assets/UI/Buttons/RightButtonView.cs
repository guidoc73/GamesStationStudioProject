using UnityEngine.EventSystems;

public class RightButtonView : ButtonView
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _controller.ButtonPressed<WalkRightButtonPressedEvent>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _controller.ButtonReleased<WalkRightButtonReleasedEvent>();
    }
}
