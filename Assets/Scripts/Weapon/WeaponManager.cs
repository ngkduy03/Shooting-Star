using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;
    [SerializeField]
    private Transform[] projectileSpawn;
    private float shootTimer;
    private bool canShoot;
    private Projectile projectile;
    private void Awake() {
        // projectile = GetComponent<Projectile>();
    }
    private void Update() {
        
    }
    void HandlePlayerShooting(){

    }

}
