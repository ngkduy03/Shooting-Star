using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    [field: SerializeField]
    public RocketData Data { get; private set; }

    private float avgRocketDamage;

    private void Start()
    {
        avgRocketDamage = CalculatDamage(Data);
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }
}
