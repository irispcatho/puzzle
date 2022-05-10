using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideOfBlock : MonoBehaviour
{
    [Range(1, 4)]
    public int TopBotLeftRight;
    public bool isPlaced;
    bool isTouchingGround;
    public float timeToDispawn;
    Vector3 posWhenItsPlaced;
    const float timeToScaleDownBloc = 1f;

    public void MakeDisappear()
    {
        transform.DOScale(0, timeToScaleDownBloc).OnComplete(DestroyBloc);
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
