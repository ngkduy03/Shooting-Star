using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : Projectile
{
    [SerializeField]
    private RocketData data;
    public RocketData Data => data;

    private void Start()
    {
        CalculatDamage(Data);
    }

    private void Update()
    {
        ProjectileMovement(Data);
    }
}
