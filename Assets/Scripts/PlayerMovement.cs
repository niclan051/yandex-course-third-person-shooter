using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 1f;
    
    private Rigidbody _rb;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        var transformedDirection = _camera!.transform.TransformDirection(new Vector3(input.x, 0, input.y) * movementSpeed);
        _rb.velocity = new Vector3(transformedDirection.x, _rb.velocity.y, transformedDirection.z);
    }
}
