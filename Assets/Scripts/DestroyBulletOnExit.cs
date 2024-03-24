using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBulletOnExit : MonoBehaviour {
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Bullet")) Destroy(other.gameObject);
    }
}
