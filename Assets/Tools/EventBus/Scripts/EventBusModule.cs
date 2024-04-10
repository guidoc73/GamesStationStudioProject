public static class EventBusModule 
{
    public static void Init()
    {
        DependencyManager.Set(new EventBus());
    }

    public static void Shutdown()
    {
        DependencyManager.ClearAll();
    }
}
