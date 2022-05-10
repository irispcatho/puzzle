using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionGround : MonoBehaviour
{
    public bool isTouchingGround;
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
        }
    }
}
