using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerMovement : MonoBehaviour
{
    const float timeToMovePlayer = 1f;
    public bool isOnBumperCar;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("BlocMovement") && other.GetComponent<SideOfBlock>().isPlaced)
        {
            print("salut on est en contact avec : " + other);
            other.GetComponent<Collider>().enabled = false;
            StartCoroutine(MovePlayer(other.GetComponent<SideOfBlock>().TopBotLeftRight));
            other.GetComponent<SideOfBlock>().MakeDisappear();
        }
        else if (other.CompareTag("BlocRotate") && other.GetComponent<SideOfBlock>().isPlaced)
        {
            print("salut on est en contact rotate avec : " + other);
            other.GetComponent<Collider>().enabled = false;
            other.GetComponent<SideOfBlock>().MakeDisappear();
            other.GetComponent<SideOfBlock>().StuckToPlayer();
            MainGame.Instance.RotateMap();
        }
        if (other.CompareTag("BumperCar"))
            isOnBumperCar = true;
    }

    public IEnumerator MovePlayer(int side)
    {
        yield return new WaitForSeconds(timeToMovePlayer);
        MainGame.Instance.Move(side);
    }
}
