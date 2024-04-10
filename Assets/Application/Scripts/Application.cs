using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
    private const int MAIN_SCENE = 0;

    [SerializeField] private CharacterFactory _characterFactory;
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EvilSquareManager _evilSquareManager;

    private IEventBus _eventBus;

    void Start()
    {
        InstantiateCharacter();
        var poolInstance = Instantiate(_pool);
        var evilSquareManagerInstance = Instantiate(_evilSquareManager);
        evilSquareManagerInstance.SetPool(poolInstance);

    }
    private void OnEnable()
    {
        InitModules();

        _eventBus = DependencyManager.Get<IEventBus>();

        _eventBus.Subscribe<PauseButtonPressedEvent>(PauseGame);
        _eventBus.Subscribe<ResumeButtonPressedEvent>(ResumeGame);
        _eventBus.Subscribe<RestartButtonPressedEvent>(RestartGame);
    }


    private void OnDisable()
    {
        _eventBus.Unsubscribe<PauseButtonPressedEvent>(PauseGame);
        _eventBus.Unsubscribe<ResumeButtonPressedEvent>(ResumeGame);
        _eventBus.Unsubscribe<RestartButtonPressedEvent>(RestartGame);

        ShutdownModules();
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
        _eventBus.UnsubscribeAll();
        SceneManager.LoadScene(MAIN_SCENE);
    }
    private void InitModules()
    {
        EventBusModule.Init();
    }

    private void ShutdownModules()
    {
        EventBusModule.Shutdown();
    }
}
