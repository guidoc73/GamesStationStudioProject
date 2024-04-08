using UnityEngine;

public class CharacterFactory : MonoBehaviour
{
    [SerializeField] private CharacterView character;

    public void InstantiateCharacterInTheCenterOfTheScene()
    {
        if (character == null) return;

        var newCharacter = Instantiate(character, Vector2.zero, Quaternion.identity);
    }
}