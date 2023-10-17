using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] projectileSpawn;

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private Rocket rocket;

    [SerializeField]
    ProjectilePoolingManger projectilePoolingManger;
    private float shootBulletTimer;
    private float shootRocketTimer;
    private bool canShoot;
    private bool canShootRocket;
    private AudioSource audioSource;

    private void Awake()
    {
        shootBulletTimer = 0f;
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

    private void HandlePlayerShooting()
    {
        if (canShoot && Input.GetMouseButton(0))
        {
            projectilePoolingManger.ShootBullet(projectileSpawn[0]);
            projectilePoolingManger.ShootBullet(projectileSpawn[1]);
            audioSource.PlayOneShot(bullet.Data.spawnSound);
            canShoot = false;
            shootBulletTimer = Time.time + bullet.Data.shootingTimeTreshold;
        }

        if (canShootRocket && Input.GetMouseButton(1))
        {
            projectilePoolingManger.ShootRocket(projectileSpawn[2]);
            audioSource.PlayOneShot(rocket.Data.spawnSound);
            canShootRocket = false;
            shootRocketTimer = Time.time + rocket.Data.shootingTimeTreshold;
        }
    }

    private void UpdateCanShoot()
    {
        if (shootBulletTimer < Time.time)
        {
            canShoot = true;
        }

        if (shootRocketTimer < Time.time)
        {
            canShootRocket = true;
        }
    }
}
