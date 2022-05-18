using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class Menu : MonoBehaviour
{
    public Image Fade;
    public GameObject FadeObj;

    public static Menu Instance;

    private void Awake()
    {
        //if (Instance != null && Instance != this)
          //  Destroy(gameObject);    // Suppression d'une instance précédente (sécurité)
        Instance = this;
    }
    private void Start()
    {
        SetActiveFadeTrue();
        Fade.DOFade(0, 2f).OnComplete(SetActiveFadeFalse);
    }
    private void SetActiveFadeFalse()
    {
        FadeObj.SetActive(false);
    }
    public void SetActiveFadeTrue()
    {
        FadeObj.SetActive(true);
    }

    public void FadeOut()
    {
        Fade.DOFade(1, 1f);
    }

    public void OnClickPlay()
    {
        Fade.DOFade(1, 1f).OnComplete(FadeCompletePlay);
    }

    private void FadeCompletePlay()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void OnClickCredits()
    {
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteCredits);
    }

    private void FadeCompleteCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void OnClickMenu()
    {
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteMenu);
    }

    private void FadeCompleteMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SetActiveFadeTrue();
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteRestart);
    }
    private void FadeCompleteRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
