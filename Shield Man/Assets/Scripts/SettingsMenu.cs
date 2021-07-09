using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("joystick button 7") || (Input.GetKeyDown(KeyCode.Escape))){
            if (Globals.SettingsOpen)
            {
                Globals.SettingsOpen = false;
                settingsMenuUI.SetActive(false);
                pauseMenuUI.SetActive(true);
            }
        }
    }

    public void Back()
    {
    	settingsMenuUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void Brightness()
    {

    }

    public void Volume()
    {
    	
    }
}