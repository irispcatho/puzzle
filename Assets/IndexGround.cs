using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexGround : MonoBehaviour
{
    public int indexZ;
    public static IndexGround instance;

    private void Awake()
    {
        instance = this;
    }
}
