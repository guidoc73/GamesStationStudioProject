using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject _content;
    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBus.Instance.Subscribe<PauseButtonPressedEvent>(PauseGame);
        EventBus.Instance.Subscribe<ResumeButtonPressedEvent>(ResumeGame);
    }

    private void OnDisable()
    {
        EventBus.Instance.Unsubscribe<PauseButtonPressedEvent>(PauseGame);
        EventBus.Instance.Unsubscribe<ResumeButtonPressedEvent>(ResumeGame);
    }

    private void PauseGame()
    {
        _content.SetActive(true);
    }
    private void ResumeGame()
    {
        _content.SetActive(false);
    }
}
