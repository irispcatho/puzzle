using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.DOMove(new Vector3(-1, 0, -1), 2f, false);
    }

}
