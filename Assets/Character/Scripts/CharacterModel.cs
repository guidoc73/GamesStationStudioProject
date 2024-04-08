using System;

public class CharacterModel
{
    public Action<bool> OnJumpChanged;
    public Action OnDeadChanged;
    public Action<float> OnVelocityChanged;

    public float MoveSpeed { get; private set; } = 10;
    public float Jumpforce { get; private set; } = 20;
    public float HorizontalVelocity { get; private set; }

    public bool IsWalkingLeft { get; private set; }
    public bool IsWalkingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsOnGround { get; private set; }
    public int Lifes { get; private set; } = 3;
    public bool IsDead { get; private set; }

    public void SetWalkingLeft(bool value)
    {
        IsWalkingLeft = value;
    }

    public void SetWalkingRight(bool value)
    {
        IsWalkingRight = value;
    }

    public void SetJumping(bool value)
    {
        IsJumping = value;
    }

    public void SetOnGround(bool value)
    {
        IsOnGround = value;
        OnJumpChanged?.Invoke(!value);
    }

    public void SetHorizontalVelocity(float value)
    {
        HorizontalVelocity = value;
        OnVelocityChanged?.Invoke(HorizontalVelocity);
    }
    public void SetLifes(int currentLife)
    {
        Lifes = currentLife;
    }

    public void SetDead(bool value)
    {
        IsDead = value;
        OnDeadChanged?.Invoke();
    }
}
