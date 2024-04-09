using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBus<bool>.Instance.Subscribe(CustomEvents.PAUSE, PauseGame);
        EventBus<bool>.Instance.Subscribe(CustomEvents.UNPAUSE, UnpauseGame);
    }

    private void OnDisable()
    {
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.PAUSE, PauseGame);
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.UNPAUSE, UnpauseGame);
    }

    private void PauseGame(bool obj)
    {
        _content.SetActive(true);
    }
    private void UnpauseGame(bool obj)
    {
        _content.SetActive(false);
    }
}
