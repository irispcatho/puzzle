using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionGround : MonoBehaviour
{
    public bool isTouchingGround;
    public bool isTouchingFence;
    public bool isTouchingFerrisWheel;
    public bool isTouchingBumperCar;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = true;
        if(other.CompareTag("Fence"))
            isTouchingFence = true;
        if (other.CompareTag("Ferris"))
            isTouchingFerrisWheel = true;
        if (other.CompareTag("BumperCar"))
            isTouchingBumperCar = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
            isTouchingGround = false;
        if (other.CompareTag("Fence"))
            isTouchingFence = false;
        if (other.CompareTag("Ferris"))
            isTouchingFerrisWheel = false;
        if (other.CompareTag("BumperCar"))
            isTouchingBumperCar = false;
    }
}
