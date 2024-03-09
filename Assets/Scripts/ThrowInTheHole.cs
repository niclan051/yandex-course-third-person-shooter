using UnityEngine;

public class ThrowInTheHole : MonoBehaviour
{
    [SerializeField] private GameObject grenadePrefab;
    [SerializeField] private Transform grenadeSpawnPoint;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate(grenadePrefab, grenadeSpawnPoint.position, grenadeSpawnPoint.rotation).GetComponent<Rigidbody>().AddForce(grenadeSpawnPoint.TransformDirection(0, 300, 300));
        }
    }
}