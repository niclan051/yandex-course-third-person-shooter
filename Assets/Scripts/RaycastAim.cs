using UnityEngine;

public class RaycastAim : MonoBehaviour
{
    private Camera _camera;
    public bool IsColliding { get; internal set; }
    private Vector3 CollisionPoint { get; set; }
    private void Start() {
        _camera = Camera.main!;
    }
    private void Update()
    {
        if (Physics.Raycast(_camera.ViewportPointToRay(new Vector3(0.5f, 0.5f)), out var hit, 100))
        {
            if (!hit.collider.isTrigger)
            {
                CollisionPoint = hit.point;
                transform.position = CollisionPoint;
                IsColliding = true;
            }
        }
        else
        {
            IsColliding = false;
        }
    }
}
