using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int WhichScene = 0;
    public int LevelsUnlocked;
    

    public static ChangeScene Instance;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (Instance != null && Instance != this)
            Destroy(gameObject);    // Suppression d'une instance pr�c�dente (s�curit�)
        Instance = this;
    }

    public void UpdateScene()
    {
        WhichScene++;
        print("go to scene : Niv " + WhichScene);
        Menu.Instance.SetFadeTrue();
        Menu.Instance.FadeOut();
        StartCoroutine(waitToChangeLvl());
    }

    public void ChooseLevel(int which)
    {
        AudioManager.instance.Play("ClicMenu");
        WhichScene = which;
        print("go to scene : Niv " + WhichScene);
        Menu.Instance.SetFadeTrue();
        Menu.Instance.FadeOut();
        StartCoroutine(waitToChangeLvl());
    }

    IEnumerator waitToChangeLvl()
    {
        yield return new WaitForSeconds(1f);
        if (WhichScene >= 15)
            SceneManager.LoadScene("Menu");
        SceneManager.LoadScene("Niv " + WhichScene);
    }

    
}
