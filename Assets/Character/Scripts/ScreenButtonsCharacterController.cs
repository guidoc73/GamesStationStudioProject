using UnityEngine;

public class ScreenButtonsCharacterController : MonoBehaviour
{
    private const int MAX_HORIZONTAL_VELOCITY = 8;
    private const int DAMAGE_AMOUNT = 1;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CharacterView _view;

    private CharacterModel _model;

    private void OnEnable()
    {
        _model = new CharacterModel();
        EventBus.Instance.Publish<LifeChangedEvent>(_model.Lifes);
        SubscribeEvents();
        BindViewToModelEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeEvents();
        UnbindViewToModelEvents();
    }

    private void FixedUpdate()
    {
        if (IsDead()) return;

        MovingActions();
    }

    private void MovingActions()
    {
        if (_model.IsOnGround)
            if (_model.IsWalkingLeft)
            {
                _rb.velocity += Vector2.left * _model.MoveSpeed;
            }
            else if (_model.IsWalkingRight)
            {
                _rb.velocity += Vector2.right * _model.MoveSpeed;
            }
            else if (_model.IsJumping)
            {
                _rb.velocity += Vector2.up * _model.Jumpforce;
            }

        _rb.velocity = GetClampedHorizontalVelocity();
        _model.SetHorizontalVelocity(_rb.velocity.x);
    }

    private Vector2 GetClampedHorizontalVelocity()
    {
        var clampedHorizontalVelocity = Mathf.Clamp(_rb.velocity.x, -MAX_HORIZONTAL_VELOCITY, MAX_HORIZONTAL_VELOCITY);
        return new Vector2(clampedHorizontalVelocity, _rb.velocity.y);
    }
    private void SubscribeEvents()
    {
        EventBus.Instance.Subscribe<WalkRightButtonPressedEvent>(SetWalkingRight);
        EventBus.Instance.Subscribe<WalkRightButtonReleasedEvent>(SetStopWalkingRight);

        EventBus.Instance.Subscribe<WalkLeftButtonPressedEvent>(SetWalkingLeft);
        EventBus.Instance.Subscribe<WalkLeftButtonReleasedEvent>(SetStopWalkingLeft);

        EventBus.Instance.Subscribe<JumpButtonPressedEvent>(SetJumping);
        EventBus.Instance.Subscribe<JumpButtonReleasedEvent>(SetStopJumping);
    }

    private void UnsubscribeEvents()
    {
        EventBus.Instance.Unsubscribe<WalkRightButtonPressedEvent>(SetWalkingRight);
        EventBus.Instance.Unsubscribe<WalkRightButtonReleasedEvent>(SetStopWalkingRight);

        EventBus.Instance.Unsubscribe<WalkLeftButtonPressedEvent>(SetWalkingLeft);
        EventBus.Instance.Unsubscribe<WalkLeftButtonReleasedEvent>(SetStopWalkingLeft);

        EventBus.Instance.Unsubscribe<JumpButtonPressedEvent>(SetJumping);
        EventBus.Instance.Unsubscribe<JumpButtonReleasedEvent>(SetStopJumping);
    }

    public void SetOnGround(bool value) => _model.SetOnGround(value);
    private bool IsDead() => _model.IsDead;

    private void SetWalkingRight() => _model.SetWalkingRight(true);
    private void SetStopWalkingRight() => _model.SetWalkingRight(false);

    private void SetWalkingLeft() => _model.SetWalkingLeft(true);
    private void SetStopWalkingLeft() => _model.SetWalkingLeft(false);

    private void SetJumping() => _model.SetJumping(true);
    private void SetStopJumping() => _model.SetJumping(false);

   
    private void BindViewToModelEvents()
    {
        _model.OnJumpChanged += _view.SetJumpingAnimTrigger;
        _model.OnVelocityChanged += _view.SetVelocity;
        _model.OnDeadChanged += _view.SetDeadTrigger;
    }

    private void UnbindViewToModelEvents()
    {
        _model.OnJumpChanged -= _view.SetJumpingAnimTrigger;
        _model.OnVelocityChanged -= _view.SetVelocity;
        _model.OnDeadChanged -= _view.SetDeadTrigger;
    }

    private void GetDamage()
    {
        if (_model.IsDead) return;

        var newLifeAmount = _model.Lifes - DAMAGE_AMOUNT;

        _model.SetLifes(newLifeAmount);
        EventBus.Instance.Publish<GetDamageEvent>();
        EventBus.Instance.Publish<LifeChangedEvent>(newLifeAmount);

        if (_model.Lifes == 0)
        {
            _model.SetDead(true);
            EventBus.Instance.Publish<DeadEvent>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("EvilSquare"))
        {
            GetDamage();
        }
    }
}