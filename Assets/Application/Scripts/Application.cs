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
        EventBus<bool>.Instance.Subscribe(CustomEvents.PAUSE, PauseGame);
        EventBus<bool>.Instance.Subscribe(CustomEvents.UNPAUSE, UnpauseGame);
        EventBus<bool>.Instance.Subscribe(CustomEvents.RESTART, RestartGame);
    }
    private void OnDisable()
    {
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.PAUSE, PauseGame);
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.UNPAUSE, UnpauseGame);
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.RESTART, RestartGame);
    }

    private void InstantiateCharacter()
    {
        _characterFactory.InstantiateCharacterInTheCenterOfTheScene();
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = 0 ;
    }

    private void UnpauseGame(bool value)
    {
        Time.timeScale = 1;
    }
    private void RestartGame(bool obj)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(MAIN_SCENE);
    }
}
