using System;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void SetVelocity(float value)
    {
        animator.SetFloat("Velocity", value);
    }

    public void SetJumpingAnimTrigger(bool value)
    {
        animator.SetBool("Jumping", value);
    }

    internal void SetDeadTrigger()
    {
        animator.SetTrigger("Dead");
    }
}
