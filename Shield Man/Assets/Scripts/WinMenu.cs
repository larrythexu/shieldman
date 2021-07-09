using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;
    public Text countText;
    public int ThreeStarScore;
    public int TwoStarScore;

    public GameObject StarA;
    public GameObject StarB;
    public GameObject StarC;
    public GameObject TwoStarA;
    public GameObject TwoStarB;

    bool menuCalled = false;

    GameObject MyEventSystem;

    void Start()
    {
        MyEventSystem = GameObject.Find("EventSystem");

    }
    // Update is called once per frame
    void Update()
    {
        if (Globals.IsGameOver && Globals.Win && !menuCalled)
        {
            if(Globals.Score >= ThreeStarScore){
                StarA.SetActive(true);
                StarB.SetActive(true);
                StarC.SetActive(true);
            } else if(Globals.Score >= TwoStarScore){
                TwoStarA.SetActive(true);
                TwoStarB.SetActive(true);
            } else{
                StarB.SetActive(true);
            }

            Globals.IsPaused = true;
            countText.text = "";
            WinMenuUI.SetActive(true);
            GameObject ContinueButton = GameObject.Find("ContinueButton");
            MyEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(ContinueButton);
            Time.timeScale = 0f;
            menuCalled = true;

        }

        if (Input.GetKeyDown("joystick button 7") || (Input.GetKeyDown(KeyCode.Escape)))
        {
            if (Globals.IsGameOver)
            {
                LoadMenu();
            }
        }
    }

    public void Resume()
    {
        WinMenuUI.SetActive(false);
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

    public void ContinueLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < 6) { 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Resume();

            Globals.UltCharge = 0;
            Globals.Streak = 0;
            Globals.Score = 0;
        }

        else
        {
            LoadMenu();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();

        Globals.UltCharge = 0;
        Globals.Streak = 0;
    }
}
