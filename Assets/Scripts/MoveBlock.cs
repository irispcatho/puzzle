using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveBlock : MonoBehaviour
{
    public Transform Target, Mouse;
    public bool isCatched, isCloseToTarget, isPlaced;

    Vector3 InitialPos, worldPosition;
    Plane plane = new Plane(Vector3.up, -1);
    public float Speed;
    const float offsetToInit = .05f;
    const float distanceToSnap = 3f;


    public static MoveBlock Instance;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        InitialPos = transform.position;
        print("Ini" + InitialPos);
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
            StartCoroutine(MakeMoveBloc());
        }
    }

    public IEnumerator MakeMoveBloc()
    {
        transform.DOScale(0, 1f);

        yield return new WaitForSeconds(2f);

        isPlaced = false;
        isCloseToTarget = false;
        GetComponent<SideOfBlock>().HasMovedPlayer = false;

        transform.position = InitialPos;
        transform.DOScale(new Vector3(1.5f, 0.0813f, 1.5f), 1f);
    }


    void Update()
    {
        if (isCatched)
        {
            float Distance = Vector3.Distance(Target.position, Mouse.position);
            //print("Distance : " + Distance);
            if (Distance < distanceToSnap)
                isCloseToTarget = true;
            else
                isCloseToTarget = false;
        }


        if (isCloseToTarget && !isPlaced)
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
                if (!isPlaced)
                {
                    transform.position = Vector3.Lerp(transform.position, InitialPos, Time.deltaTime * Speed);
                    if (Math.Abs(transform.position.x - InitialPos.x) <= offsetToInit && Math.Abs(transform.position.y - InitialPos.y) <= offsetToInit && Math.Abs(transform.position.z - InitialPos.z) <= offsetToInit) //--> Permet de bien replacer le cube à sa position initiale
                        transform.position = InitialPos;
                }
            }
        }

    }

}
