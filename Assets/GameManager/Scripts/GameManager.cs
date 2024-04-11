using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager
{
    private const int MAIN_SCENE = 0;

    private IEventBus _eventBus;
    private ICharacterFactory _characterFactory;

    public GameManager(IEventBus eventBus, ICharacterFactory characterFactory)
    {
        _eventBus = eventBus;
        _characterFactory = characterFactory;

        SubscribeToGameEvents();
        InstantiateCharacter();
    }

    ~GameManager()
    {
        UnsubscribeToGameEvents();
    }

    private void SubscribeToGameEvents()
    {
        _eventBus.Subscribe<PauseButtonPressedEvent>(PauseGame);
        _eventBus.Subscribe<ResumeButtonPressedEvent>(ResumeGame);
        _eventBus.Subscribe<RestartButtonPressedEvent>(RestartGame);
    }

    private void UnsubscribeToGameEvents()
    {
        _eventBus.Unsubscribe<PauseButtonPressedEvent>(PauseGame);
        _eventBus.Unsubscribe<ResumeButtonPressedEvent>(ResumeGame);
        _eventBus.Unsubscribe<RestartButtonPressedEvent>(RestartGame);
    }

    private void InstantiateCharacter() => _characterFactory.InstantiateCharacterInTheCenterOfTheScene();

    private void PauseGame() => Time.timeScale = 0;

    private void ResumeGame() => Time.timeScale = 1;

    private void RestartGame()
    {
        ResumeGame();
        CleanEventBus();
        ReloadLevel();
    }

    private void CleanEventBus() => _eventBus.UnsubscribeAll();

    private void ReloadLevel() => SceneManager.LoadScene(MAIN_SCENE);
}
