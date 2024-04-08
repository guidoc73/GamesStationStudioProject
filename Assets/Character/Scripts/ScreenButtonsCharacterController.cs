using System;
using UnityEngine;

public class ScreenButtonsCharacterController : MonoBehaviour
{
    private const int MAX_HORIZONTAL_VELOCITY = 8;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private CharacterView _view;

    private CharacterModel _model;

    private void OnEnable()
    {
        _model = new CharacterModel();
        SubscribeEvents();
    }

    private void FixedUpdate()
    {
        MovingActions();
    }

    public void SetOnGround(bool value)
    {
        _model.SetOnGround(value);
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
    }

    private Vector2 GetClampedHorizontalVelocity()
    {
        var clampedHorizontalVelocity = Mathf.Clamp(_rb.velocity.x, -MAX_HORIZONTAL_VELOCITY, MAX_HORIZONTAL_VELOCITY);
        return new Vector2(clampedHorizontalVelocity, _rb.velocity.y);
    }


    private void SubscribeEvents()
    {
        EventBus.Instance.Subscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus.Instance.Subscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus.Instance.Subscribe(CustomEvents.JUMP, SetJumping);
    }

    private void UnsubscribeEvents()
    {
        EventBus.Instance.Unsubscribe(CustomEvents.WALK_LEFT, SetWalkingLeft);
        EventBus.Instance.Unsubscribe(CustomEvents.WALK_RIGHT, SetWalkingRight);
        EventBus.Instance.Unsubscribe(CustomEvents.JUMP, SetJumping);
    }

    private void SetWalkingLeft(bool value) => _model.SetWalkingLeft(value);
    private void SetWalkingRight(bool value) => _model.SetWalkingRight(value);
    private void SetJumping(bool value) => _model.SetJumping(value);

    private void OnDestroy()
    {
        UnsubscribeEvents();
    }
}