using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float mouseSpeed = 0.0001f;
    private void Start() {
        Cursor.visible = false;
    }
    void Update()
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        gameObject.transform.position = mousePosition;
        transform.Translate(Input.GetAxis("Horizontal")*mouseSpeed*Time.deltaTime,
            Input.GetAxis("Vertical")*mouseSpeed*Time.deltaTime,0f); 
    }
}
