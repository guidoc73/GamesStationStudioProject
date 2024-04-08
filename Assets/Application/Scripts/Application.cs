using UnityEngine;

public class Application : MonoBehaviour
{
    [SerializeField] private CharacterFactory _characterFactory;

    void Start()
    {
        InstantiateCharacter();
    }

    private void InstantiateCharacter()
    {
        _characterFactory.InstantiateCharacterInTheCenterOfTheScene();
    }
}
