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
        {
            //print("du sol du sol !!");
            isTouchingGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //print("ça quitte le sol !!");
            isTouchingGround = false;
            //StartCoroutine(DiseapperOrNot());
        }
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
