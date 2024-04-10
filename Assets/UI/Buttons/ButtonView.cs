using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected ButtonController _controller;

    private void Start()
    {
        _controller = new ButtonController();
    }

    public abstract void OnPointerDown(PointerEventData eventData);

    public abstract void OnPointerUp(PointerEventData eventData);
}
