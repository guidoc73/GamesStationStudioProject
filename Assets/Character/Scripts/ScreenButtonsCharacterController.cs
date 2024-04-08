using UnityEngine;

public class ScreenButtonsCharacterController : MonoBehaviour
{
    private const int MAX_HORIZONTAL_VELOCITY = 8;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;

    private bool IsWalkingLeft;
    private bool IsWalkingRight;
    private bool IsJumping;
    private bool IsOnGround;


    private void FixedUpdate()
    {
        MovingActions();
    }

    public void SetOnGround(bool value)
    {
        IsOnGround = value;
    }

    private void MovingActions()
    {
        if (IsOnGround)
            if (IsWalkingLeft)
            {
                _rb.velocity += Vector2.left * speed;
            }
            else if (IsWalkingRight)
            {
                _rb.velocity += Vector2.right * speed;
            }
            else if (IsJumping)
            {
                _rb.velocity += Vector2.up * jumpforce;
            }

        _rb.velocity = GetClampedHorizontalVelocity();
    }

    private Vector2 GetClampedHorizontalVelocity()
    {
        var clampedHorizontalVelocity = Mathf.Clamp(_rb.velocity.x, -MAX_HORIZONTAL_VELOCITY, MAX_HORIZONTAL_VELOCITY);
        return new Vector2(clampedHorizontalVelocity, _rb.velocity.y);
    }

    private void OnEnable()
    {
        SubscribeToEvents();
    }
    private void OnDestroy()
    {
        UnsubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        EventBus.Instance.Subscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus.Instance.Subscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus.Instance.Subscribe(CustomEvents.JUMP, SetJumping);
    }

    private void UnsubscribeToEvents()
    {
        EventBus.Instance.Unsubscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus.Instance.Unsubscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus.Instance.Unsubscribe(CustomEvents.JUMP, SetJumping);
    }

    private void SetWalkingLeft(bool value) => IsWalkingLeft = value;
    private void SetWalkingRight(bool value) => IsWalkingRight = value;
    private void SetJumping(bool value) => IsJumping = value;

}