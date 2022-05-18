using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapEffect : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z), 2f, false);
    }
}
