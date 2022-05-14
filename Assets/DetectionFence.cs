using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionFence : MonoBehaviour
{
    public bool isTouchingFence;
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Fence"))
        {
            isTouchingFence = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Fence"))
        {
            isTouchingFence = false;
        }
    }
}
