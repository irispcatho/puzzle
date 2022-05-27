using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    public TextMeshProUGUI nb;
    public GameObject Cadena;

    private void Start()
    {
        if (int.Parse(nb.text) <= ChangeScene.Instance.LevelsUnlocked)
        {
            Cadena.SetActive(false);
            print("Starto");
        }
    }

    public void OnClick()
    {
        if (ChangeScene.Instance.LevelsUnlocked >= int.Parse(nb.text))
        {
            //GetAllLvl.Instance.PutOffCadena();
            ChangeScene.Instance.ChooseLevel(int.Parse(nb.text));
        }
    }
}
