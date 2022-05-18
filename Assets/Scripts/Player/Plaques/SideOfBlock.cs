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
    public float timeToDispawn;
    Vector3 posWhenItsPlaced;
    const float timeToScaleDownBloc = 1f;

    public void MakeDisappear()
    {
        transform.DOScale(0, timeToScaleDownBloc).OnComplete(DestroyBloc);
    }

    public void StuckToPlayer()
    {
        stuckToPlayer = true;
        transform.DORotate(new Vector3(0, -90, 0), 1f);
    }

    void DestroyBloc()
    {
        Destroy(gameObject);
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
            posWhenItsPlaced = transform.position;
            yield return new WaitForSeconds(.5f);
            MakeDisappear();
        }
    }
}