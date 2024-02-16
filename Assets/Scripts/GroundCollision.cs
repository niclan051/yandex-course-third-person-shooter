using UnityEngine;

public class GroundCollision : MonoBehaviour {
    public bool IsOnGround { get; internal set; }

    private void OnTriggerStay(Collider other)
    {
        IsOnGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        IsOnGround = false;
    }
}
