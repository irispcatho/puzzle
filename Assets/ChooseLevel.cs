using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseLevel : MonoBehaviour
{
    public TextMeshProUGUI nb;

    public void OnClick()
    {
        print(nb.text);
    }
}
