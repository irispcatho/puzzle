using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToSceneManager : MonoBehaviour
{
    public bool CanUpdateScene;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SceneManager"))
        {
            if(CanUpdateScene)
            {
                other.GetComponent<ChangeScene>().UpdateScene();
                CanUpdateScene = false;
            }
        }
    }
}
