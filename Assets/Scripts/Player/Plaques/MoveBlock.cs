using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBlock : MonoBehaviour
{
    public Transform Target, Mouse;
    public bool isCatched, isCloseToTarget, isPlaced;
    public GameObject[] NbOfBloc;

    Vector3 InitialPos, worldPosition;
    Plane plane = new Plane(Vector3.up, -1);
    public float Speed;
    const float offsetToInit = .05f;
    const float distanceToSnap = 3f;
    public float Scale = 1.2f;

    public static MoveBlock Instance;
    private void Awake()
    {
        Instance = this;
    }
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

        if (!isCatched && isCloseToTarget)
        {
            isPlaced = true;
            for (int i = 0; i < NbOfBloc.Length; i++)
            {
                NbOfBloc[i].GetComponent<SideOfBlock>().isPlaced = true;
            }
        }
    }


    private void OnMouseOver()
    {
        gameObject.transform.DOScale(Scale, 0.3f);
    }


    private void OnMouseExit()
    {
        gameObject.transform.DOScale(1f, 0.3f);
    }

    void Update()
    {
        if (isCatched)
        {
            float Distance = Vector3.Distance(Target.position, Mouse.position);
            if (Distance < distanceToSnap)
                isCloseToTarget = true;
            else
                isCloseToTarget = false;
        }


        if (isCloseToTarget && !isPlaced)
            transform.position = Target.position;
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
                if (!isPlaced)
                {
                    transform.position = Vector3.Lerp(transform.position, InitialPos, Time.deltaTime * Speed);
                    if (Math.Abs(transform.position.x - InitialPos.x) <= offsetToInit && Math.Abs(transform.position.y - InitialPos.y) <= offsetToInit && Math.Abs(transform.position.z - InitialPos.z) <= offsetToInit) //--> Permet de bien replacer le cube � sa position initiale
                        transform.position = InitialPos;
                }
            }
        }
    }
}
