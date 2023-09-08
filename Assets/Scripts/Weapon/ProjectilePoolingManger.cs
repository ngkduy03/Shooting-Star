using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePoolingManger : MonoBehaviour
{
    [SerializeField]
    private List<Bullet> Bullets = new();

    [SerializeField]
    private Bullet bullet;

    [SerializeField]
    private Transform bulletStorage;
    
    [SerializeField]
    private Transform rocketStorage;

#if UNITY_EDITOR
    [ContextMenu("CreatePool")]
    private void CreateBulletsPool()
    {
        Bullets.Clear();
        
        while(bulletStorage.childCount != 0)
        {
            DestroyImmediate(bulletStorage.GetChild(0).gameObject);
        }

        for (int i = 0; i < 20; i++)
        {
            var bulletObj = Instantiate(bullet);
            bulletObj.transform.SetParent(bulletStorage);
            bulletObj.gameObject.SetActive(false);
            Bullets.Add(bullet);
        }

        UnityEditor.EditorUtility.SetDirty(this);
    }

#endif

    private int LoadBullet(int count)
    {
        int nthBullet = count % bulletStorage.childCount;
        return nthBullet;
    }

    private void ShootBullet()
    {

    }
    
}
