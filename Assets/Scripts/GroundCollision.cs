using UnityEngine;

public class GroundCollision : MonoBehaviour {
    public bool IsOnGround { get; private set; }

    private void OnTriggerStay(Collider other)
    {
        IsOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsOnGround = false;
    }
}
