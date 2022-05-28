using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllLvl : MonoBehaviour
{
    public GameObject[] LevelsToChoose;
    public int LvlUnlocked, lvlToLaunch;
    public bool isLvlChoose;

    public static GetAllLvl Instance;
    bool asMadeCadena;
    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("SceneManager"))
        {
            if (other.GetComponent<ChangeScene>().LevelsUnlocked >= LvlUnlocked)
                LvlUnlocked = other.GetComponent<ChangeScene>().LevelsUnlocked;
            if (isLvlChoose)
            {
                other.GetComponent<ChangeScene>().ChooseLevel(lvlToLaunch);
                isLvlChoose = false;
            }
            //print("hola chica");
        }
    }

    public void LaunchChooseLevel(int lvl)
    {
        lvlToLaunch = lvl;
        isLvlChoose = true;
    }


    private void Update()
    {
        print("lvl unlocked : " + LvlUnlocked);
        Cadena();
    }

    public void PutOffCadena()
    {
        asMadeCadena = false;
    }

    public void Cadena()
    {
        if (!asMadeCadena)
        {
            for (int i = 0; i < LvlUnlocked; i++)
            {
                LevelsToChoose[i].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    IEnumerator cutCadena()
    {
        yield return new WaitForSeconds(.5f);
        print("fini le cut");
        asMadeCadena = true;
    }
}
