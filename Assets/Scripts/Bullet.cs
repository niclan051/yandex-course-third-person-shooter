using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _rb.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
    }

    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
