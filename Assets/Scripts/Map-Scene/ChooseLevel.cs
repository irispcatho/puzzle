using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    public TextMeshProUGUI nb;

    public void OnClick()
    {
        if (ChangeScene.Instance.LevelsUnlocked >= int.Parse(nb.text))
        {
            GetAllLvl.Instance.PutOffCadena();
            ChangeScene.Instance.ChooseLevel(int.Parse(nb.text));
        }
    }
}
