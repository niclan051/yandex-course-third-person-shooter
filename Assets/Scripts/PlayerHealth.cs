using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : BaseHealth {
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Color noHealthColor;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Animator gameOverPanelAnimator;
    [SerializeField] private AudioSource healSound;
    
    private Renderer _renderer;
    private static readonly int TriggerSlideDown = Animator.StringToHash("Slide Down");

    protected override void Start()
    {
        base.Start();
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(noHealthColor, fullHealthColor, (float)Health / maxHealth);
        healthText.text = $"{Health}/{maxHealth}";
    }

    public override void Damage(int amount) {
        base.Damage(amount);
        if (Health == 0)
        {
            GetComponent<PlayerMovement>()!.enabled = false;
            GetComponentInChildren<FireInTheHole>()!.enabled = false;
            gameOverPanelAnimator.SetTrigger(TriggerSlideDown);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public override void Heal(int amount) {
        base.Heal(amount);
        healSound.Play();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Damage(Health / 10 + 1);
        }
    }
}
