using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MapEffect : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        gameObject.transform.DOMove(new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z), 2f, false).OnComplete(PlayerPos);
    }

    private void PlayerPos()
    {
        player.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
