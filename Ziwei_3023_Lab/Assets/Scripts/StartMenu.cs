using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public Animator animator;

    private int levelToLoad;


    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete ()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void PlayGame()
    {
        FadeToLevel(1);
    }

    public void ContinueGame()
    {
        SaveSystem.SaveStart = true;
        EditorSceneManager.LoadScene("SampleScene", UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
