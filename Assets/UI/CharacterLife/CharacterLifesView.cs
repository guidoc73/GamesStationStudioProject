using TMPro;
using UnityEngine;

public class CharacterLifesView : MonoBehaviour
{
    [SerializeField] private TMP_Text _lifes;

    // Start is called before the first frame update
    private void OnEnable()
    {
        EventBus.Instance.Subscribe<LifeChangedEvent>(SetLifes);
    }
    private void OnDisable()
    {
        EventBus.Instance.Unsubscribe<LifeChangedEvent>(SetLifes);
    }

    private void SetLifes(object currentLifes)
    {
        if (currentLifes is int value)
        {
            _lifes.text = "Lifes: " + value;
        }
    }
}
