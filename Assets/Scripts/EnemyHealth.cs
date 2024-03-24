using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyHealth : BaseHealth
{
    [SerializeField] private KillCounter killCounter;
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Color noHealthColor;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private GameObject healCollectiblePrefab;

    private Renderer _renderer;

    public override void Damage(int amount)
    {
        audioSource.PlayOneShot(hurtSound);
        base.Damage(amount);
        if (Health <= 0)
        {
            if (Random.Range(1, 10) <= 3) Instantiate(healCollectiblePrefab, transform.position, transform.rotation);
            Destroy(gameObject);
            killCounter.Kills++;
        }
    }

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponentInChildren<Renderer>();
        audioSource = GetComponent<AudioSource>();
        killCounter = FindObjectOfType<KillCounter>();
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
