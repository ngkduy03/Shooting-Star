using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private ProjectilesData data;
    private void Update()
    {
        transform.Translate(0f, data.speed * Time.deltaTime, 0f);

    }
}
