using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialMaster : MonoBehaviour
{
    //Controller variables
    public string charX = "LeftHorizontal";
    public string charY = "LeftVertical";
    public string jumpName = "AButton";
    public string shieldX = "RightHorizontal";
    public string shieldY = "RightVertical";
    public float joystickDeadzone = 0.2f;

    public TextMeshProUGUI TutorialText;

    //spawner
    Spawner spawnerScript;


    // Start is called before the first frame update
    void Start()
    {
        Globals.IsGameOver = false;
        Globals.IsPaused = false;
        Globals.SettingsOpen = false;
        Globals.Score = 0;
        Globals.IsStunned = false;
        Globals.UltCharge = 0;
        Globals.Streak = 0;

        spawnerScript = GameObject.Find("Projectile Spawner").GetComponent<Spawner>();
        StartCoroutine(Tutorial()); 
    }


    IEnumerator Tutorial()
    {
        
        //Basic controls lesson.

        TutorialText.text = "Welcome to Shield Man! First, let's show you the basics.";
        yield return new WaitForEndOfFrame();
        Spawner.spawnAllowed = false;
        yield return new WaitForSeconds(7f);
        TutorialText.text = "Use the left joystick to move left and right";
        while (!(Mathf.Abs(Input.GetAxis(charX)) >= joystickDeadzone)) yield return null;
        TutorialText.text = "Very cool. You really are ready for the big leagues!";
        yield return new WaitForSeconds(5f);
        TutorialText.text = "Now use the A button to jump";
        yield return new WaitForSeconds(2f);
        while (!Input.GetKeyDown("joystick button 0")) yield return null;
        TutorialText.text = "Your mother would be very proud of you right now. Let's move onto some real work.";
        yield return new WaitForSeconds(8f);

        //Blocking tutorial
        TutorialText.text = "Start getting used to your new shield now. You can use the right joystick to move it in any direction.";
        while (!(Mathf.Abs(Input.GetAxis(shieldX)) > joystickDeadzone || Mathf.Abs(Input.GetAxis(shieldY)) > joystickDeadzone)) yield return null;
        yield return new WaitForSeconds(5f);
        TutorialText.text = "Now let's put your shield skills to the test. Try blocking this guy.";


        spawnerScript.shootBasic(11);

        GameObject projectile = GameObject.FindGameObjectWithTag("Projectile");

        while(projectile != null)
        {
            yield return null;
        }

        TutorialText.text = "Wow, great moves. Let's try blocking a few more of them now";

        Spawner.spawnAllowed = true;

        while(Globals.Score < 10)
        {
            yield return null;
        }

        Spawner.spawnAllowed = false;

        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        for(int i = 0; i < projectiles.Length; i++)
        {
            Destroy(projectiles[i]);
            yield return new WaitForSeconds(0.2f);
        }

        TutorialText.text = "Good stuff. You really might have what it takes to go space adventuring.";
        yield return new WaitForSeconds(5f);
        TutorialText.text = "There are a wide variety of other projectiles so always be on your toes!";
        yield return new WaitForSeconds(10f);
        TutorialText.text = "Now get out there and loot some planets!";
    }
}

