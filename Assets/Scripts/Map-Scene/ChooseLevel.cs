using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    public TextMeshProUGUI nb;
    public GameObject Cadena;


    public void OnClick()
    {
        print("ça clique sur le bouton : " + nb.text);
        if (int.Parse(nb.text) <= GetAllLvl.Instance.LvlUnlocked)
        {
            GetAllLvl.Instance.PutOffCadena();
            GetAllLvl.Instance.LaunchChooseLevel(int.Parse(nb.text));
            //ChangeScene.Instance.ChooseLevel(int.Parse(nb.text));
        }
    }
}
