using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    //Vector3 mOffset;
    //float mZCoord;
    //private Vector3 GetMouseAsWorldPoint()
    //{
    //    // Pixel coordinates of mouse (x,y)
    //    Vector3 mousePoint = Input.mousePosition;
    //    // z coordinate of game object on screen
    //    mousePoint.z = mZCoord;
    //    // Convert it to world points
    //    return Camera.main.ScreenToWorldPoint(mousePoint);
    //}

    //void Start()
    //{
    //    mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
    //    mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    //}

    //private void OnMouseOver()
    //{

    //}

    //private void Update()
    //{
    //    Vector3 XX = GetMouseAsWorldPoint();
    //    XX = new Vector3(XX.x, 2, XX.z);
    //    transform.position = XX;
    //}

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
