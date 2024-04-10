public static class GameManagerModule
{
    public static void Init()
    {
        var eventBus = DependencyManager.Get<IEventBus>();
        var characterFactory = DependencyManager.Get<ICharacterFactory>();
        new GameManager(eventBus, characterFactory);
    }

    public static void Shutdown()
    {
        DependencyManager.Clear<GameManager>();
    }
}
