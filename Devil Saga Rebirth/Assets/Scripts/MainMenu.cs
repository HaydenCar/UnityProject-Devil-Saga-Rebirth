using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadCredits()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void OpenGit()
    {
        Application.OpenURL("https://github.com/HaydenCar/UnityProject-Devil-Saga-Rebirth");
    }
}
