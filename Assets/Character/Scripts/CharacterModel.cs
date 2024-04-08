public class CharacterModel
{
    public float MoveSpeed { get; private set; } = 10;
    public float Jumpforce { get; private set; } = 30;

    public bool IsWalkingLeft { get; private set; }
    public bool IsWalkingRight { get; private set; }
    public bool IsJumping { get; private set; }
    public bool IsOnGround { get; private set; }


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
    }
}
