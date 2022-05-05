using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BlocMovement"))
        {
            print("salut");
            if (!other.GetComponent<SideOfBlock>().HasMovedPlayer)
            {
                StartCoroutine(MovePlayer(other));
                other.GetComponent<SideOfBlock>().HasMovedPlayer = true;
            }
        }
    }

    public IEnumerator MovePlayer(Collider other)
    {
        yield return new WaitForSeconds(1f);
        MainGame.Instance.Move(other.GetComponent<SideOfBlock>().TopBotLeftRight);
    }
}
