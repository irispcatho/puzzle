using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloc2 : MonoBehaviour
{
    public Transform Target, Mouse;
    public bool isCatched, isCloseToTarget;
    Vector3 InitialPos;
    public Vector3 worldPosition;
    Plane plane = new Plane(Vector3.up, -2);
    public float Speed;
    const float offsetToInit = .1f;

    private void Start()
    {
        InitialPos = transform.position;
    }

    private void OnMouseDown()
    {
        isCatched = true;
    }

    private void OnMouseUp()
    {
        isCatched = false;
    }

    void Update()
    {
        if (isCatched)
        {
            float Distance = Vector3.Distance(Target.position, Mouse.position);
            //print("Distance : " + Distance);
            if (Distance < 2)
                isCloseToTarget = true;
            else
                isCloseToTarget = false;
        }


        if (isCloseToTarget)
        {
            transform.position = Target.position;
        }
        else
        {
            if (isCatched)
            {
                float distance;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (plane.Raycast(ray, out distance))
                {
                    worldPosition = ray.GetPoint(distance);
                    transform.position = worldPosition;
                }
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, InitialPos, Time.deltaTime * Speed);
                if (Math.Abs(transform.position.x - InitialPos.x) <= offsetToInit && Math.Abs(transform.position.y - InitialPos.y) <= offsetToInit && Math.Abs(transform.position.z - InitialPos.z) <= offsetToInit) //--> Permet de bien replacer le cube à sa position initiale
                    transform.position = InitialPos;
            }
        }

    }
}
