using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float mouseSpeed = 60f;
    private void Start() {
       Cursor.lockState = CursorLockMode.Locked; 
    }
    void Update()
    {
        Vector2 mousePosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        transform.Translate(Input.GetAxis("Mouse X")*mouseSpeed*Time.deltaTime,
            Input.GetAxis("Mouse Y")*mouseSpeed*Time.deltaTime,0f); 
    }
}
