using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bloc : MonoBehaviour
{
    public Transform Target;
    public Collider Player;
    public bool isEnter, isPlaced; //--> repasse en privée après les tests
    Vector3 mOffset;
    float mZCoord;
    Vector3 InitialPos;
    public float Speed = 5;
    const float offsetToInit = .1f;

    private void Start()
    {
        InitialPos = transform.position;
    }

   

    void OnMouseDown()
    {
        Player.enabled = true;
        print("je clique sur le cube");
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private void OnMouseUp()
    {
        isEnter = false;
        if ((transform.position == InitialPos) || transform.position == Target.position)
        {
            isPlaced = true;
            print("C'est placé" + isPlaced);
        }
        else
            isPlaced = false;
        //print("init" + InitialPos);
        //print("trans" + transform.position);
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
            isPlaced = true;
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
        if (!isPlaced)
        {
            Player.enabled = false;
            //transform.position = Vector3.MoveTowards(transform.position, InitialPos, Speed * Time.deltaTime); //--> Avance à une vitesse constante
            transform.position = Vector3.Lerp(transform.position, InitialPos, Time.deltaTime* Speed);
            if (Math.Abs(transform.position.x - InitialPos.x) <= offsetToInit && Math.Abs(transform.position.y - InitialPos.y) <= offsetToInit && Math.Abs(transform.position.z - InitialPos.z) <= offsetToInit) //--> Permet de bien replacer le cube à sa position initiale
                transform.position = InitialPos;
                //isPlaced = true;
            //  transform.position = new Vector3((Mathf.Round(transform.position.x * 100.0f) * 0.01f), (Mathf.Round(transform.position.y * 100.0f) * 0.01f), (Mathf.Round(transform.position.z * 100.0f) * 0.01f));

            if (transform.position == InitialPos)
                isPlaced = true;
        }
        else
        {
            Player.enabled = true;
        }

        
    }
}
