using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, -2);
    void Update()
    {
        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            worldPosition = ray.GetPoint(distance);
            transform.position = worldPosition;
        }
    }
}
