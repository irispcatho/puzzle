using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionGround : MonoBehaviour
{
    public bool isTouchingGround;
    public bool isTouchingFerrisWheel;
    public bool isTouchingBumperCar;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = true;
        if (other.CompareTag("Ferris"))
            isTouchingFerrisWheel = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = false;
        if (other.CompareTag("Ferris"))
            isTouchingFerrisWheel = false;
    }
}
