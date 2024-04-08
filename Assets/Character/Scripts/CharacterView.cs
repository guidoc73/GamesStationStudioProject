using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetVelocity(float value)
    {
        animator.SetFloat("Velocity", value);
    }
}
