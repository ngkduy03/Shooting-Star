using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;

public class ProjectilePoolingManger : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> Bullets = new();
    private Queue<Bullet> DeactiveBullets = new();

    [SerializeField]
    private List<Rocket> Rockets = new();

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private Rocket rocket;

    [SerializeField]
    private Transform bulletStorage;

    [SerializeField]
    private Transform rocketStorage;

    private int countBulletNum = 0;
    private int countRocketNum = 0;
    private bool isBulletSpawnesd = false;

#if UNITY_EDITOR
    [ContextMenu("CreateBulletPool")]
    private void CreateBulletPool()
    {
        Bullets.Clear();

        while (bulletStorage.childCount != 0)
        {
            DestroyImmediate(bulletStorage.GetChild(0).gameObject);
        }

        for (int i = 0; i < 20; i++)
        {
            var bulletObj = Instantiate(bullet);
            bulletObj.transform.SetParent(bulletStorage);
            bulletObj.gameObject.SetActive(false);
            Bullets.Add(bulletObj);
        }

        UnityEditor.EditorUtility.SetDirty(this);
    }

    [ContextMenu("CreateRocketPool")]
    private void CreateRocketPool()
    {
        Rockets.Clear();

        while (rocketStorage.childCount != 0)
        {
            DestroyImmediate(rocketStorage.GetChild(0).gameObject);
        }

        for (int i = 0; i < 3; i++)
        {
            var rocketObj = Instantiate(rocket);
            rocketObj.transform.SetParent(rocketStorage);
            rocketObj.gameObject.SetActive(false);
            Rockets.Add(rocketObj);
        }

        UnityEditor.EditorUtility.SetDirty(this);
    }
#endif

    public void ShootBullet(Transform spawnPoint)
    {
        int LoadBullet(int count)
        {
            int nthBullet = count % bulletStorage.childCount;
            return nthBullet;
        }

        Bullets[LoadBullet(countBulletNum)].transform.position = spawnPoint.position;
        Bullets[LoadBullet(countBulletNum)].gameObject.SetActive(true);
        Bullets[LoadBullet(countBulletNum)].DespawnProjectile().Forget();
        countBulletNum++;
    }

    public void ShootBulletV2(Transform spawnPoint)
    {
        // for (int i = 0; i < Bullets.Count; i++)
        // {
        //     if (!Bullets[i].gameObject.activeInHierarchy)
        //     {
        //         Bullets[i].transform.position = spawnPoint.position;
        //         Bullets[i].gameObject.SetActive(true);
        //         Bullets[i].DespawnBullet().Forget();
        //         isBulletSpawnesd = true;
        //         break;
        //     }
        //     else
        //     {
        //         isBulletSpawnesd = false;
        //     }
        // }

        if(DeactiveBullets.Count > 0)
        {
            var bullet = DeactiveBullets.Peek();
            bullet.transform.position = spawnPoint.position;
            bullet.gameObject.SetActive(true);
            bullet.DespawnProjectile().Forget();
            DeactiveBullets.Dequeue();
        }
        else    
        {
            Bullet newBullet = Instantiate(bullet,spawnPoint.position,quaternion.identity);
            newBullet.DespawnProjectile().Forget();
            Bullets.Add(newBullet);
            newBullet.transform.SetParent(bulletStorage);
            LoadDeactiveBullet(newBullet).Forget();
        }
    }

    private async UniTask LoadDeactiveBullet(Bullet bullet)
    {
        await UniTask.WaitUntil(() => bullet.IsDeactivated == true);
        DeactiveBullets.Enqueue(bullet);
    }

    public void ShootRocket(Transform spawnPoint)
    {
        int LoadRocket(int count)
        {
            int nthRocket = count % rocketStorage.childCount;
            return nthRocket;
        }

        Rockets[LoadRocket(countRocketNum)].transform.position = spawnPoint.position;
        Rockets[LoadRocket(countRocketNum)].gameObject.SetActive(true);
        Rockets[LoadRocket(countRocketNum)].DespawnProjectile().Forget();
        countRocketNum++;
    }
}
