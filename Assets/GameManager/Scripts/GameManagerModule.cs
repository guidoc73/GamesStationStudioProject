public static class GameManagerModule
{
    public static void Init()
    {
        var eventBus = DependencyManager.Get<IEventBus>();
        new GameManager(eventBus);
    }

    public static void Shutdown()
    {
        DependencyManager.Clear<GameManager>();
    }
}
