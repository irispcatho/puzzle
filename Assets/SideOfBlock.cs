using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideOfBlock : MonoBehaviour
{
    [Range(1, 4)]
    public int TopBotLeftRight;
    public bool HasMovedPlayer;


    //public void StartMoveBlock()
    //{
    //    StartCoroutine(MakeMoveBloc());
    //}

    //public IEnumerator MakeMoveBloc()
    //{
    //    transform.DOScale(0, 1f);

    //    yield return new WaitForSeconds(2f);

    //    isPlaced = false;
    //    isCloseToTarget = false;
    //    GetComponent<SideOfBlock>().HasMovedPlayer = false;
    //    //GetComponent<Collider>().enabled = true;

    //    transform.position = InitialPos;
    //    transform.DOScale(new Vector3(1.5f, 0.0813f, 1.5f), 1f);
    //}

    //public static SideOfBlock Instance;
    //private void Awake()
    //{
    //    Instance = this;
    //}
}
