using UnityEngine;

public class FireInTheHole : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private float cooldown;

    private float _timer;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        audioSource = GetComponent<AudioSource>();
    }
    
    private void Update()
    {
        if (Input.GetMouseButton(0) && _timer >= cooldown)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            audioSource.PlayOneShot(shootSound);
            _timer = 0;
        }

        _timer += Time.deltaTime;
    }
}
