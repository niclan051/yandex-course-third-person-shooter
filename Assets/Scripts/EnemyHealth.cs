using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : BaseHealth
{
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Color noHealthColor;

    private Renderer _renderer;

    public override void Damage(int amount)
    {
        base.Damage(amount);
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(noHealthColor, fullHealthColor, (float)Health / maxHealth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            Damage(1);
        }
    }
}
