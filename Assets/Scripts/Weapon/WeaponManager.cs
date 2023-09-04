using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] projectileSpawn;

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private Rocket rocket;

    private float shootTimer;
    private float shootRocketTimer;
    private bool canShoot;
    private bool canShootRocket;
    private AudioSource audioSource;

    private void Awake()
    {
        shootTimer = 0f;
        shootRocketTimer = 0f;
        canShoot = true;
        canShootRocket = true;
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        UpdateCanShoot();
        HandlePlayerShooting();
    }

    void HandlePlayerShooting()
    {

        if (canShoot && Input.GetMouseButton(0))
        {
            Instantiate(bullet, projectileSpawn[0].position, Quaternion.identity);
            Instantiate(bullet, projectileSpawn[1].position, Quaternion.identity);
            audioSource.PlayOneShot(bullet.Data.spawnSound);
            canShoot = false;
            shootTimer = Time.time + bullet.Data.shootingTimeTreshold;
        }

        if (canShootRocket && Input.GetMouseButton(1))
        {
            Instantiate(rocket, projectileSpawn[2].position, Quaternion.identity);
            audioSource.PlayOneShot(rocket.Data.spawnSound);
            canShootRocket = false;
            shootRocketTimer = Time.time + rocket.Data.shootingTimeTreshold;
        }
    }

    void UpdateCanShoot()
    {
        if (shootTimer < Time.time)
        {
            canShoot = true;
        }

        if (shootRocketTimer < Time.time)
        {
            canShootRocket = true;
        }
    }
}
