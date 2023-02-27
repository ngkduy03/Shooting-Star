using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private Transform[] projectileSpawn;
    [SerializeField] private ProjectilesData projectilesData;
    [SerializeField] private ProjectilesData rocketData;
    // [SerializeField] private ProjectilesFactory m_projectileFactory;
    private float shootTimer;
    private float shootRocketTimer;
    private bool canShoot;
    private bool canShootRocket;
    private void Awake()
    {
        shootTimer = 0f;
        shootRocketTimer = 0f;
        canShoot = true;
        canShootRocket = true;
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
            // m_projectileFactory.Create(ProjectilesFactory.Projectile_t.RedBlaster, projectileSpawn[0].position);  
            // m_projectileFactory.Create(ProjectilesFactory.Projectile_t.RedBlaster, projectileSpawn[1].position);  
            Instantiate(projectilesData.projectilePrefap,
                projectileSpawn[0].position, Quaternion.identity);
            Instantiate(projectilesData.projectilePrefap,
                projectileSpawn[1].position, Quaternion.identity);
            canShoot = false;
            shootTimer = Time.time + projectilesData.shootingTimeTreshold;
        }

        if (canShootRocket && Input.GetMouseButton(1))
        {
            Instantiate(rocketData.projectilePrefap,
                projectileSpawn[2].position, Quaternion.identity);
            canShootRocket = false;
            shootRocketTimer = Time.time + rocketData.shootingTimeTreshold;
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
