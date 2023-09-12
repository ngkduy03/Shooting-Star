using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Projectile : MonoBehaviour
{
    protected float LivingTime = 2f;
    protected void ProjectileMovement(ProjectilesData data)
    {
        transform.Translate(0f, data.speed * Time.deltaTime, 0f);
    }

    protected float CalculatDamage(ProjectilesData data)
    {
        return Random.Range(data.minDamage, data.maxDamage);
    }
    public async UniTaskVoid DespawnBullet()
    {
        await UniTask.WaitForSeconds(LivingTime);
        gameObject.SetActive(false);
    }
}
