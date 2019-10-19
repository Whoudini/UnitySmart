using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    private Vector3 offset;
    private float cordinate;
    void OnMouseDown()
    {
        cordinate = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;


        offset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private Vector3 GetMouseAsWorldPoint()

    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = cordinate;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }
    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + offset;

    }
}

