using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public void Play1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void Play2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void Play3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void Play4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level4");
    }

    public void Play5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level5");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Back()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Tutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("ControllerMap");
    }
}
