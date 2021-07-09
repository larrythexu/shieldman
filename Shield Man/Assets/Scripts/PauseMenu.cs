using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    GameObject MyEventSystem;

    private void Start()
    {
        MyEventSystem = GameObject.Find("EventSystem");
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("joystick button 7") || (Input.GetKeyDown(KeyCode.Escape))) && !Globals.IsGameOver){
            if (!Globals.SettingsOpen)
            {
                if (Globals.IsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
    }

    public void Resume()
    {
    	pauseMenuUI.SetActive(false);
    	Time.timeScale = 1f;
        Globals.IsPaused = false;
        Globals.IsGameOver = false;
    }

    void Pause()
    {
    	pauseMenuUI.SetActive(true);
        GameObject ResumeButton = GameObject.Find("ResumeButton");
        MyEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(ResumeButton);
        Time.timeScale = 0f;
        Globals.IsPaused = true;
    }

    public void LoadMenu()
    { 
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
        Globals.IsPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();

        Globals.UltCharge = 0;
        Globals.Streak = 0;
    }
}
