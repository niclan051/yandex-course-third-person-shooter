using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        OnCollected(other);
    }
    private void OnCollisionEnter(Collision other)
    {
        OnCollected(other.collider);
    }

    protected virtual void OnCollected(Collider collector)
    {
        Destroy(gameObject);
    }
}