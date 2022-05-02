using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bloc : MonoBehaviour
{
    public Transform Target;
    public Collider Player;
    private Vector3 mOffset;
    private float mZCoord;
    public bool isEnter;
    public bool isMouseUp;

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
        isMouseUp = false;
    }

    private void OnMouseUp()
    {
        isMouseUp = true;
    }


    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        // z coordinate of game object on screen
        mousePoint.z = mZCoord;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        if(!isEnter)
            transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        print("yo");
        if (other == Player)
        {
            transform.position = Target.transform.position;
            //Player.GetComponent<Collider>().enabled = false;
            isEnter = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isEnter = false;
        //Player.GetComponent<Collider>().enabled = true;
    }


    private void Update()
    {
        //if(isEnter)
           // transform.position = Player.transform.position;
    }
}
