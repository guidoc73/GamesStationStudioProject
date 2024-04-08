using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterButtonView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private CustomEvents _customEvent;

    private ButtonController _controller;

    private void Start()
    {
        _controller = new ButtonController(_customEvent);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _controller.StartAction();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _controller.StopAction();
    }
}
