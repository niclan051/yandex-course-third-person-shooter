using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    protected int Health;

    protected virtual void Start()
    {
        Health = maxHealth;
    }

    public virtual void Damage(int amount)
    {
        Health = Mathf.Max(0, Health - amount);
    }

    public virtual void Heal(int amount)
    {
        Health += amount;
    }
}