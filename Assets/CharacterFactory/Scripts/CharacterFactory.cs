using UnityEngine;

public class CharacterFactory : MonoBehaviour, ICharacterFactory
{
    [SerializeField] private CharacterView character;

    private void OnEnable()
    {
        DependencyManager.Set<ICharacterFactory>(this);
    }

    private void OnDisable()
    {
        DependencyManager.Clear<ICharacterFactory>();
    }

    public void InstantiateCharacterInTheCenterOfTheScene()
    {
        if (character == null) return;

        Instantiate(character, Vector2.zero, Quaternion.identity);
    }
}
