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
        SetFadeTrue();
        Fade.DOFade(0, 2f).OnComplete(SetFadeFalse);
    }
    private void SetFadeFalse()
    {
        FadeObj.SetActive(false);
    }
    public void SetFadeTrue()
    {
        FadeObj.SetActive(true);
    }

    public void FadeOut()
    {
        Fade.DOFade(1, 1f);
    }

    public void OnClickPlay()
    {
        AudioManager.instance.Play("ClicMenu");
        SetFadeTrue();
        Fade.DOFade(1, 1f).OnComplete(FadeCompletePlay);
    }

    private void FadeCompletePlay()
    {
        SceneManager.LoadScene("LevelSelection");
        //SetFadeFalse();
    }

    public void OnClickCredits()
    {
        AudioManager.instance.Play("ClicMenu");
        SetFadeTrue();
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteCredits);
    }

    private void FadeCompleteCredits()
    {
        SceneManager.LoadScene("Credits");
        //SetFadeFalse();
    }

    public void OnClickMenu()
    {
        AudioManager.instance.Play("ClicMenu");
        SetFadeTrue();
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteMenu);
    }

    private void FadeCompleteMenu()
    {
        SceneManager.LoadScene("Menu");
        //SetFadeFalse();
    }

    public void OnClickQuit()
    {
        AudioManager.instance.Play("ClicMenu");
        Application.Quit();
    }

    public void Restart()
    {
        SetFadeTrue();
        Fade.DOFade(1, 1f).OnComplete(FadeCompleteRestart);
    }
    private void FadeCompleteRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
