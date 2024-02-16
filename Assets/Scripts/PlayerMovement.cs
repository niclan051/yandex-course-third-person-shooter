using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    [SerializeField] private float jumpVelocity = 1f;
    
    private Rigidbody _rb;
    private GroundCollision _groundCollision;
    private bool _spacePressed;
    private Camera _camera;
    private Animator _animator;

    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _groundCollision = GetComponentInChildren<GroundCollision>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rb.velocity = transform.TransformDirection(new Vector3(input.x, 0, input.y) * movementSpeed) +
                       new Vector3(0, _rb.velocity.y, 0);

        _spacePressed = Input.GetButtonDown("Jump");

        if (input.magnitude > 0.1f)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation.y = _camera!.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(rotation);
        }
        
        _animator.SetBool(AnimationConstants.BoolFalling, _rb.velocity.y < 0);
        _animator.SetFloat(AnimationConstants.FloatInputHorizontal, input.x);
        _animator.SetBool(AnimationConstants.BoolInputHorizontalZero, input.x == 0);
        _animator.SetFloat(AnimationConstants.FloatInputVertical, input.y);
        _animator.SetBool(AnimationConstants.BoolInputVerticalZero, input.y == 0);
        _animator.SetBool(AnimationConstants.BoolOnGround, _groundCollision.IsOnGround);
    }

    private void FixedUpdate()
    {
        if (!_spacePressed || !_groundCollision.IsOnGround)
        {
            _animator.ResetTrigger(AnimationConstants.TriggerJump);
            return;
        }

        var soonToBeVelocity = _rb.velocity;
        soonToBeVelocity.y = jumpVelocity;
        _rb.velocity = soonToBeVelocity;
        _groundCollision.IsOnGround = false;
        
        _animator.SetTrigger(AnimationConstants.TriggerJump);
    }
}
