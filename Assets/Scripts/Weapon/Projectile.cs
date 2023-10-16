using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Projectile : MonoBehaviour
{
    protected float livingTime = 2f;

    public bool IsDeactivated;

    protected void ProjectileMovement(ProjectilesData data)
    {
        transform.Translate(0f, data.speed * Time.deltaTime, 0f);
    }

    protected float CalculatDamage(ProjectilesData data)
    {
        return Random.Range(data.minDamage, data.maxDamage);
    }

    public async UniTaskVoid DespawnProjectile()
    {
        await UniTask.WaitForSeconds(livingTime);
        gameObject.SetActive(false);
        IsDeactivated = true;
    }
}
