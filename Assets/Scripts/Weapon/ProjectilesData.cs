using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObjects", menuName = "ScriptableObjects/Projectiles")]
public class ProjectilesData : ScriptableObject
{
    public string nameTag;
    public float speed;
    public float minDamage;
    public float maxDamage;
    public float shootingTimeTreshold;
    public AudioClip spawnSound;
}
