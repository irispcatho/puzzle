using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionGround : MonoBehaviour
{
    public bool isTouchingGround;
    public bool isTouchingFence;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            //print("du sol du sol !!");
            isTouchingGround = true;
        }
        if(other.CompareTag("Fence"))
        {
            isTouchingFence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Fence"))
        {
            //print("ça quitte le sol !!");
            isTouchingGround = false;
        }
        if (other.CompareTag("Fence"))
        {
            isTouchingFence = false;
        }
    }
}
