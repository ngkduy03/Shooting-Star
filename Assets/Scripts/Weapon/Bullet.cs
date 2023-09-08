using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Bullet : Projectile
{
    [field: SerializeField]
    public BulletData Data { get; private set; }

    [SerializeField]
    private float LivingTime = 3f;

    private void Start()
    {
        CalculatDamage(Data);
        DespawnBullet().Forget();
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }

    private async UniTaskVoid DespawnBullet()
    {
        await UniTask.WaitForSeconds(LivingTime);
        gameObject.SetActive(false);
    }

    private void SpawnBullet(Vector3 spawnpoint, GameObject bullet)
    {
        bullet.SetActive(true);
        bullet.transform.position = spawnpoint;
    }

}
