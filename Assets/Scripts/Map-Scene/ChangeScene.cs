using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int WhichScene = 1;

    public static ChangeScene Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }

    public void UpdateScene()
    {
        WhichScene++;
        print("go to scene : Niv " + WhichScene);
        Menu.Instance.SetActiveFadeTrue();
        Menu.Instance.FadeOut();
        StartCoroutine(waitToChange());
    }

    IEnumerator waitToChange()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Niv " + WhichScene);
    }
}
