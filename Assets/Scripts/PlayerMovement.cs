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

    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        _groundCollision = GetComponentInChildren<GroundCollision>();
    }

    private void Update()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        _rb.velocity = transform.TransformDirection(new Vector3(input.x, 0, input.y) * movementSpeed) +
                       new Vector3(0, _rb.velocity.y, 0);

        _spacePressed = Input.GetButton("Jump");

        if (input.magnitude > 0.1f)
        {
            var rotation = transform.rotation.eulerAngles;
            rotation.y = _camera!.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(rotation);
        }
    }

    private void FixedUpdate()
    {
        if (!_spacePressed || !_groundCollision.IsOnGround) return;
        
        var soonToBeVelocity = _rb.velocity;
        soonToBeVelocity.y = jumpVelocity;
        _rb.velocity = soonToBeVelocity;
    }
}
