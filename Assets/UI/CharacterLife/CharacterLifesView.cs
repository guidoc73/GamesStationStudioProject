using System;
using TMPro;
using UnityEngine;

public class CharacterLifesView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifes;

    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBus<int>.Instance.Subscribe(CustomEvents.GETDAMAGE, SetLifes);
    }

    private void SetLifes(int value)
    {
        _lifes.text = "Lifes: " + value;
    }

    private void OnDisable()
    {
        EventBus<int>.Instance.Unsubscribe(CustomEvents.GETDAMAGE, SetLifes);
    }
}
