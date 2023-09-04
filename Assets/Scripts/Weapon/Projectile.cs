using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected void ProjectileMovement(ProjectilesData data)
    {
        transform.Translate(0f, data.speed * Time.deltaTime, 0f);
    }

    protected void CalculatDamage(ProjectilesData data)
    {
        Random.Range(data.minDamage, data.maxDamage);
    }
}
