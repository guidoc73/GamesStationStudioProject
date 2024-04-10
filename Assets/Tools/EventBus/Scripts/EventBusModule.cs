public static class EventBusModule 
{
    public static void Init()
    {
        DependencyManager.Set<IEventBus>(new EventBus());
    }

    public static void Shutdown()
    {
        DependencyManager.Clear<IEventBus>();
    }
}
