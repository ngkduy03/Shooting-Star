using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
   public enum ProjectileType
   {
    Blaster1,
    Blaster2,
    Laser,
    Missile,
    Rocket
   }
   private float damage;
   private float speed;
   [SerializeField]
   private AudioClip spawnSound;
   [SerializeField]
   private AudioClip destroySound;
   [SerializeField]
   private GameObject bombEffect;
   [SerializeField]
   private ProjectileType projectileType;
    void Start()
    {
        if(projectileType == ProjectileType.Blaster1)
        {
            damage = Random.Range(5,10);
            speed = 30;
        } 
        if(projectileType == ProjectileType.Blaster2)
        {
            damage = Random.Range(10,15);
            speed = 35;
        } 
        if(projectileType == ProjectileType.Laser)
        {
            damage = 9;
            speed = 45;
        } 
        if(projectileType == ProjectileType.Missile)
        {
            damage = Random.Range(20,25);
            speed = 16;
        } 
        if(projectileType == ProjectileType.Rocket)
        {
            damage = 40;
            speed = 32;
        }
        if(spawnSound){
            AudioSource.PlayClipAtPoint(spawnSound,new Vector3 (0f,5f,0f));
        } 
    }
    void Update()
    {
        ProjectileMovement();
    }
    private void ProjectileMovement(){
        transform.Translate(0f,speed*Time.deltaTime,0f);
    }
}
