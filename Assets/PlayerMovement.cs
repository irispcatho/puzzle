using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool isMoving;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlocMovement"))
        {
            print("salut");
            if (!other.GetComponent<SideOfBlock>().HasMovedPlayer && !isMoving)
            {
                StartCoroutine(MovePlayer(other));
                other.GetComponent<SideOfBlock>().HasMovedPlayer = true;
                print("c qui" + other);
                //other.GetComponent<Collider>().enabled = false;
            }
        }
    }

    public IEnumerator MovePlayer(Collider other)
    {
        isMoving = true;
        yield return new WaitForSeconds(1f);
        MainGame.Instance.Move(other.GetComponent<SideOfBlock>().TopBotLeftRight);
        other.GetComponent<MoveBlock>().StartMoveBlock();
        isMoving = false;
    }
}
