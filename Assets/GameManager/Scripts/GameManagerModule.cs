public static class GameManagerModule
{
    public static void Init()
    {
        var eventBus = DependencyManager.Get<IEventBus>();
        DependencyManager.Set<IGameManager>(new GameManager(eventBus));
    }

    public static void Shutdown()
    {
        DependencyManager.Clear<IGameManager>();
    }
}
