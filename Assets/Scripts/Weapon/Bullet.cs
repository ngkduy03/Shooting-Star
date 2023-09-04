using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Bullet : Projectile
{
    [SerializeField]
    private BulletData data;
    public BulletData Data => data;

    private void Start()
    {
        CalculatDamage(Data);
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }
}
