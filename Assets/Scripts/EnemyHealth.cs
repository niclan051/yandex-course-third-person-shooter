using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;
    private int _health;
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Color noHealthColor;

    private Renderer _renderer;

    public void Damage(int damage)
    {
        _health = Math.Max(0, _health - damage);
        if (_health == 0)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _health = maxHealth;
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(noHealthColor, fullHealthColor, (float)_health / maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage(1);
        }
    }
}
