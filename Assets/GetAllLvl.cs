using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllLvl : MonoBehaviour
{
    public GameObject[] LevelsToChoose;

    public static GetAllLvl Instance;
    bool asMadeCadena;
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }

    private void Start()
    {
        //Cadena();
        print("blablala");
    }

    public void LaunchCadena()
    {
        print("ça lance");
        //Cadena();
    }

    public void Cadena()
    {
        for (int i = 0; i < ChangeScene.Instance.LevelsUnlocked; i++)
        {
            LevelsToChoose[i].transform.GetChild(1).gameObject.SetActive(false);
        }
        asMadeCadena = true;
    }
}
