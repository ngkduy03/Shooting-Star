using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class ProjectilePoolingManger : MonoBehaviour
{
    private Queue<Bullet> Bullets = new();

    [SerializeField]
    private Bullet bullet;

    private Queue<Rocket> Rockets= new();

    [SerializeField]
    private Rocket rocket;

    [SerializeField]
    private Transform bulletStorage;

    [SerializeField]
    private Transform rocketStorage;

    private int countBulletNum = 0;
    private int countRocketNum = 0;
    private bool isBulletSpawnesd = false;
    private bool isRocketSpawned = false;

    public void ShootBullet(Transform spawnPoint)
    {
        if(Bullets.Count > 0)
        {
            var bullet = Bullets.Peek();
            bullet.transform.position = spawnPoint.position;
            bullet.gameObject.SetActive(true);
            bullet.DespawnProjectile().Forget();
            Bullets.Dequeue();
            bullet.IsDeactivated = false;
            LoadDeactiveProjectiles(bullet, Bullets).Forget();
            isBulletSpawnesd = true;
        }
        else    
        {
            isBulletSpawnesd = false;
        }

        if(!isBulletSpawnesd)
        {
            Bullet newBullet = Instantiate(bullet,spawnPoint.position,quaternion.identity);
            newBullet.DespawnProjectile().Forget();
            newBullet.transform.SetParent(bulletStorage);
            LoadDeactiveProjectiles(newBullet, Bullets).Forget();
            newBullet.IsDeactivated = false;
        }
    }
    public void ShootRocket(Transform spawnPoint)
    {
        if(Rockets.Count > 0)
        {
            var rocket = Rockets.Peek();
            rocket.transform.position = spawnPoint.position;
            rocket.gameObject.SetActive(true);
            rocket.DespawnProjectile().Forget();
            Bullets.Dequeue();
            rocket.IsDeactivated = false;
            LoadDeactiveProjectiles(rocket, Rockets).Forget();
            isRocketSpawned = true;
        }
        else    
        {
            isRocketSpawned = false;
        }

        if(!isRocketSpawned)
        {
            Rocket newRocket = Instantiate(rocket,spawnPoint.position,quaternion.identity);
            newRocket.DespawnProjectile().Forget();
            newRocket.transform.SetParent(rocketStorage);
            LoadDeactiveProjectiles(newRocket,Rockets).Forget();
            newRocket.IsDeactivated = false;
        }
    }

    private async UniTaskVoid LoadDeactiveProjectiles<T>(T projectile, Queue<T> DeactiveProjectiles) where T:Projectile
    {
        await UniTask.WaitUntil(() => projectile.IsDeactivated == true);
        DeactiveProjectiles.Enqueue(projectile);
    }

}
