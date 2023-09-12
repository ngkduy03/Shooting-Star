using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolingManger : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> Bullets = new();

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

    public void ShootBullet(Vector3 spawnPosition)
    {
        int LoadBullet(int count)
        {
            int nthBullet = count % bulletStorage.childCount;
            return nthBullet;
        }

        Bullets[LoadBullet(countBulletNum)].transform.position = spawnPosition;
        Bullets[LoadBullet(countBulletNum)].gameObject.SetActive(true);
        Bullets[LoadBullet(countBulletNum)].DespawnBullet().Forget();
        countBulletNum++;
    }

    public void ShootRocket(Vector3 spawnPosition)
    {
        int LoadRocket(int count)
        {
            int nthRocket = count % rocketStorage.childCount;
            return nthRocket;
        }

        Rockets[LoadRocket(countRocketNum)].transform.position = spawnPosition;
        Rockets[LoadRocket(countRocketNum)].gameObject.SetActive(true);
        Rockets[LoadRocket(countRocketNum)].DespawnBullet().Forget();
        countRocketNum++;
    }
}
