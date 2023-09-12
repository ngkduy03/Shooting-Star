using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Bullet : Projectile
{
    [field: SerializeField]
    public BulletData Data { get; private set; }

    private float avgBulletDamage;

    private void Start()
    {
        avgBulletDamage  = CalculatDamage(Data);
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }

}
