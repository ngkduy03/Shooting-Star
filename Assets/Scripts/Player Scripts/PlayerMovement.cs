using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void Start() {
       Cursor.lockState = CursorLockMode.Locked; 
       transform.position = new Vector2(0,-15); 
    }
    void Update()
    {
        Vector2 mousePosition = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        HandleMovement(99f);
    }
    private void HandleMovement(float speed){
        transform.position = new Vector2(Mathf.Clamp(transform.position.x,-50f,50f),
            Mathf.Clamp(transform.position.y,-27f,28f));
        transform.Translate(Input.GetAxis("Mouse X")*speed*Time.deltaTime,
            Input.GetAxis("Mouse Y")*speed*Time.deltaTime,0f);
    }
}
