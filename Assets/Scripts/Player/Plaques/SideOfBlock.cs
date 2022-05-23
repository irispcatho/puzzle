using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideOfBlock : MonoBehaviour
{
    [Range(1, 4)]
    public int TopBotLeftRight;
    public bool isPlaced, stuckToPlayer;
    bool isTouchingGround;
    const float timeToDestroy = 2f;

    public void MakeDisappear()
    {
        //transform.DOScale(0, timeToScaleDownBloc).OnComplete(DestroyBloc);
        transform.DOMoveY(2.3f, timeToDestroy);
        gameObject.GetComponentInChildren<MeshRenderer>().material.DOFade(0, timeToDestroy).OnComplete(DestroyBloc);
        //gameObject.GetComponentInChildren<MeshRenderer>().material.DOFade(0, 2f).OnComplete(DestroyBloc);
    }
    void DestroyBloc()
    {
        Destroy(gameObject);
    }

    public void StuckToPlayer()
    {
        stuckToPlayer = true;
        transform.DOMove(new Vector3(0, -90, 0), 1f);
    }

    private void Update()
    {
        if (isPlaced && !isTouchingGround)
        {
            StartCoroutine(DiseapperOrNot());
            isPlaced = false;
        }

        if (stuckToPlayer)
        {
            transform.position = new Vector3(MainGame.Instance.Player.transform.position.x, transform.position.y, MainGame.Instance.Player.transform.position.z);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = false;
    }

    IEnumerator DiseapperOrNot()
    {
        if (isPlaced)
        {
            yield return new WaitForSeconds(.5f);
            MakeDisappear();
        }
    }
}
