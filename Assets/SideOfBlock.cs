using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SideOfBlock : MonoBehaviour
{
    [Range(1, 4)]
    public int TopBotLeftRight;
    public bool isPlaced;
    const float timeToScaleBloc = 1f;

    public void MakeDisappear()
    {
        transform.DOScale(0, timeToScaleBloc).OnComplete(DestroyBloc);
    }

    void DestroyBloc()
    {
        Destroy(gameObject);
    }
}
