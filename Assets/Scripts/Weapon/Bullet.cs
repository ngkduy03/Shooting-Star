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
    private float LivingTime = 2f;

    private float avgDamage;

    private void Start()
    {
        avgDamage = CalculatDamage(Data);
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }

    public async UniTaskVoid DespawnBullet()
    {
        await UniTask.WaitForSeconds(LivingTime);
        gameObject.SetActive(false);
    }
}
