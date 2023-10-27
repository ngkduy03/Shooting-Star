using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera myCamera;

    [SerializeField]
    private PolygonCollider2D myCollider;

    public Vector2 WorldUnitsInCamera;
    private float cursorSpeed = 100f;
    private float maxX;
    private float minX;
    private float maxY;
    private float minY;

    private void Start()
    {
        WorldUnitsInCamera.y = myCamera.orthographicSize;
        WorldUnitsInCamera.x = WorldUnitsInCamera.y * Screen.width / Screen.height;

        Cursor.lockState = CursorLockMode.Locked;
        transform.position = new Vector2(0, -15);

        maxX = WorldUnitsInCamera.x - myCollider.bounds.size.x;
        minX = -WorldUnitsInCamera.x + myCollider.bounds.size.x;
        maxY = WorldUnitsInCamera.y - myCollider.bounds.size.y / 2;
        minY = -WorldUnitsInCamera.y + myCollider.bounds.size.y;
    }

    void Update()
    {
        HandleMovement(cursorSpeed);
    }

    private void HandleMovement(float speed)
    {
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
        );

        transform.Translate(
            Input.GetAxis("Mouse X") * speed * Time.deltaTime,
            Input.GetAxis("Mouse Y") * speed * Time.deltaTime,
            0f
        );
    }
}
