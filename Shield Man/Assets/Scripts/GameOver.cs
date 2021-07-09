using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverMenuUI;
    public Text countText;

    bool menuCalled = false;

    GameObject MyEventSystem;

    void Start()
    {
        MyEventSystem = GameObject.Find("EventSystem");
    }
    // Update is called once per frame
    void Update()
    {
    	if(Globals.IsGameOver && !Globals.Win && !menuCalled){
            Globals.IsPaused = true;
            countText.text = "";
    		gameOverMenuUI.SetActive(true);
            GameObject RestartButton = GameObject.Find("RestartButton");
            MyEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(RestartButton);
            Time.timeScale = 0f;
            menuCalled = true;
    	}
    		
        if(Input.GetKeyDown("joystick button 7") || (Input.GetKeyDown(KeyCode.Escape)))
        {
            if (Globals.IsGameOver)
            {
                LoadMenu();
            }
        }
    }

    public void Resume()
    {
        gameOverMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Globals.IsPaused = false;
        Globals.IsGameOver = false;
    }

    public void LoadMenu()
    {
        Globals.IsPaused = false;
        Globals.IsGameOver = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();

        Globals.UltCharge = 0;
        Globals.Streak = 0;
    }
}