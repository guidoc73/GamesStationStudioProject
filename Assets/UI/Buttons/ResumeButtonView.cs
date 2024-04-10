using UnityEngine.EventSystems;

public class ResumeButtonView : ButtonView
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        _controller.ButtonPressed<ResumeButtonPressedEvent>();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _controller.ButtonReleased<ResumeButtonReleasedEvent>();
    }
}
