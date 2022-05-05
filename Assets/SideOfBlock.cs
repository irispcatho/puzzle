using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideOfBlock : MonoBehaviour
{
    [Range(1, 4)]
    public int TopBotLeftRight;
    public bool HasMovedPlayer;

    public static SideOfBlock Instance;
    private void Awake()
    {
        Instance = this;
    }
}
