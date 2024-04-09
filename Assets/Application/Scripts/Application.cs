using UnityEngine;

public class Application : MonoBehaviour
{
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

    private void InstantiateCharacter()
    {
        _characterFactory.InstantiateCharacterInTheCenterOfTheScene();
    }
}
