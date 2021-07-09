using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialMenu : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(KeyCode.Return))
        {
            PlayTutorial();
        }
    }
    public void PlayTutorial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }
}
