using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    [SerializeField] private int maxHealth = 100;
    private int _health;
    [SerializeField] private Color fullHealthColor;
    [SerializeField] private Color noHealthColor;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Animator gameOverPanel;
    
    private Renderer _renderer;
    private static readonly int TriggerSlideDown = Animator.StringToHash("Slide Down");

    private void Start() {
        _health = maxHealth;
        _renderer = GetComponentInChildren<Renderer>();
    }

    private void Update()
    {
        _renderer.material.color = Color.Lerp(noHealthColor, fullHealthColor, (float)_health / maxHealth);
        healthSlider.value = (float)_health / maxHealth;
    }

    public void Damage(int amount) {
        _health = Math.Max(0, _health - amount);
        if (_health == 0)
        {
            GetComponent<PlayerMovement>()!.enabled = false;
            GetComponentInChildren<FireInTheHole>()!.enabled = false;
            gameOverPanel.SetTrigger(TriggerSlideDown);
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            Damage(10);
        }
    }
}
