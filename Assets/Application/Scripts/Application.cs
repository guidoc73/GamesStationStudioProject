using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
    private const int MAIN_SCENE = 0;

    [SerializeField] private CharacterFactory _characterFactory;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EvilSquareManager _evilSquareManager;

    void Start()
    {
        InstantiateCharacter();
        var poolInstance = Instantiate(_pool);
        var evilSquareManagerInstance = Instantiate(_evilSquareManager);
        evilSquareManagerInstance.SetPool(poolInstance);

    }
    private void OnEnable()
    {
        EventBus.Instance.Subscribe<PauseButtonPressedEvent>(PauseGame);
        EventBus.Instance.Subscribe<ResumeButtonPressedEvent>(ResumeGame);
        EventBus.Instance.Subscribe<RestartButtonPressedEvent>(RestartGame);
    }
    private void OnDisable()
    {
        EventBus.Instance.Unsubscribe<PauseButtonPressedEvent>(PauseGame);
        EventBus.Instance.Unsubscribe<ResumeButtonPressedEvent>(ResumeGame);
        EventBus.Instance.Unsubscribe<RestartButtonPressedEvent>(RestartGame);
    }

    private void InstantiateCharacter()
    {
        _characterFactory.InstantiateCharacterInTheCenterOfTheScene();
    }

    private void PauseGame()
    {
        Time.timeScale = 0 ;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
    private void RestartGame()
    {
        Time.timeScale = 1;
        EventBus.Instance.UnsubscribeAll();
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
