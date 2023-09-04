using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ScriptableObjects", menuName = "ScriptableObjects/Projectiles/Rocket", order = 2)]
public class RocketData : ProjectilesData
{
    public AudioClip destroySound;
    public GameObject bombEffect;
}
