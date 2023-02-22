using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObkects", menuName = "ScriptableObjects/Projectiles")]
public class ProjectilesData : ScriptableObject
{
    public string type;
    public float speed;
    public float damage;
    public float shootingTimeTreshold;
    public AudioClip spawnSound;
    public AudioClip DestroySound;
    public GameObject bombEffect;
    public GameObject projectilePrefap;
}
