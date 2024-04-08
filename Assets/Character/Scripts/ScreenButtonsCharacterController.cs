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
        EventBus<int>.Instance.Publish(CustomEvents.GETDAMAGE, _model.Lifes);
        SubscribeEvents();
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

    public void SetOnGround(bool value) => _model.SetOnGround(value);
    private bool IsDead() => _model.IsDead;
    private void SetWalkingLeft(bool value) => _model.SetWalkingLeft(value);
    private void SetWalkingRight(bool value) => _model.SetWalkingRight(value);
    private void SetJumping(bool value) => _model.SetJumping(value);

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
    private void SubscribeEvents()
    {
        EventBus<bool>.Instance.Subscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus<bool>.Instance.Subscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus<bool>.Instance.Subscribe(CustomEvents.JUMP, SetJumping);
        _model.OnJumpChanged += _view.SetJumpingAnimTrigger;
        _model.OnVelocityChanged += _view.SetVelocity;
        _model.OnDeadChanged += _view.SetDeadTrigger;
    }
    private void UnsubscribeEvents()
    {
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus<bool>.Instance.Unsubscribe(CustomEvents.JUMP, SetJumping);
        _model.OnJumpChanged -= _view.SetJumpingAnimTrigger;
        _model.OnVelocityChanged -= _view.SetVelocity;
        _model.OnDeadChanged += _view.SetDeadTrigger;
    }

    private void GetDamage()
    {
        if (_model.IsDead) return;

        var newLifeAmount = _model.Lifes - DAMAGE_AMOUNT;

        _model.SetLifes(newLifeAmount);
        EventBus<int>.Instance.Publish(CustomEvents.GETDAMAGE, newLifeAmount);

        if (_model.Lifes == 0)
            _model.SetDead(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("EvilSquare"))
        {
            GetDamage();
        }
    }
}