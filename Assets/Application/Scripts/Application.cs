using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    [SerializeField] private EvilSquareManager _evilSquareManager;

    void Start()
    {
        var poolInstance = Instantiate(_pool);
        var evilSquareManagerInstance = Instantiate(_evilSquareManager);
        evilSquareManagerInstance.SetPool(poolInstance);
    }

    private void OnEnable()
    {
        InitModules();
    }

    private void OnDisable()
    {
        ShutdownModules();
    }

    private void InitModules()
    {
        EventBusModule.Init();
        GameManagerModule.Init();
    }
    private void ShutdownModules()
    {
        EventBusModule.Shutdown();
        GameManagerModule.Shutdown();
    }
}
