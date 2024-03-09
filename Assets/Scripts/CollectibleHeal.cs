using UnityEngine;

public class CollectibleHeal : Collectible
{
    [SerializeField] private int healAmount = 10;
    protected override void OnCollected(Collider collector) {
        var playerHealth = collector.GetComponent<PlayerHealth>();
        if (playerHealth != null) {
            playerHealth.Heal(healAmount);
        }
        base.OnCollected(collector);
    }
}
