using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New ScriptableObjects", menuName = "ScriptableObjects/FactoryProjectiles")]
public class ProjectilesFactory : ScriptableObject
{
    public enum Projectile_t
    {
        RedBlaster,
        YellowBlaster
    };

    public SerializableDictionary<Projectile_t, GameObject> projDic;
    public GameObject Create(Projectile_t i_type, Vector3 i_Spawnlocation)
    {
        GameObject obj = null;
        obj = Instantiate(projDic._myDictionary[i_type], i_Spawnlocation, Quaternion.identity);
        return obj;
    }
}
