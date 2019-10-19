using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 20f;
    public float border = 10f;
    public Vector2 panlimit;

    public float scrollSpeed = 20f;
    public float minY = 20f;
    public float maxY = 120f;

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - border)
        {
            position.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= border)
        {
            position.z -= speed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - border)
        {
            position.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= border)
        {
            position.x -= speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        position.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        position.x = Mathf.Clamp(position.x, -panlimit.x, panlimit.x);
        position.y = Mathf.Clamp(position.y, minY, maxY);
        position.z = Mathf.Clamp(position.z, -panlimit.y, panlimit.y);

        transform.position = position;
    }
}
