using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Level5Master : MonoBehaviour
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
        Spawner.spawnAllowed = true;
        StartCoroutine(LevelFive());
    }

    IEnumerator LevelFive()
    {
        //basic - duos
        //intro
        spawnerScript.shootBasic(11);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootBasic(8);
        spawnerScript.shootBasic(0);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(4);
        yield return new WaitForSeconds(6f); 
        //couples
        spawnerScript.shootBasic(5);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootBasic(1);
        spawnerScript.shootBasic(2);
        spawnerScript.shootBasic(7);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootBasic(11);
        yield return new WaitForSeconds(2.5f);
        spawnerScript.shootBasic(8);
        spawnerScript.shootBasic(9);
        yield return new WaitForSeconds(10f);
        
        //fast - waves
        spawnerScript.shootFast(8);
        spawnerScript.shootFast(11);
        yield return new WaitForSeconds(1.8f);
        spawnerScript.shootFast(10);
        spawnerScript.shootFast(9);
        yield return new WaitForSeconds(3.5f); 

        spawnerScript.shootFast(0);
        spawnerScript.shootFast(3);
        yield return new WaitForSeconds(0.8f);
        spawnerScript.shootFast(1);
        spawnerScript.shootFast(2);
        yield return new WaitForSeconds(3f);

        spawnerScript.shootFast(7);
        spawnerScript.shootFast(4);
        yield return new WaitForSeconds(0.8f);
        spawnerScript.shootFast(6);
        spawnerScript.shootFast(5);
        yield return new WaitForSeconds(1.5f);

        spawnerScript.shootFast(2);
        spawnerScript.shootFast(3);
        yield return new WaitForSeconds(3f);
        spawnerScript.shootFast(8);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootFast(9);
        yield return new WaitForSeconds(2f);

        spawnerScript.shootFast(8);
        spawnerScript.shootFast(11);
        yield return new WaitForSeconds(3f);

        spawnerScript.shootFast(0);
        spawnerScript.shootFast(4);
        yield return new WaitForSeconds(8f);

        //rockets - blanket
        spawnerScript.shootRocket(8);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(9);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(10);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(11);
        yield return new WaitForSeconds(2f);

        spawnerScript.shootRocket(1);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(5);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(2);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(6);
        yield return new WaitForSeconds(3.5f);

        spawnerScript.shootRocket(11);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(10);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(9);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(8);
        yield return new WaitForSeconds(2f);

        spawnerScript.shootRocket(3);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(7);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootRocket(8);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(11);
        yield return new WaitForSeconds(2f);

        spawnerScript.shootRocket(0);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(4);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(7);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootRocket(3);
        yield return new WaitForSeconds(10f);

        //lasers - dash dance
        spawnerScript.shootLaser(8);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootLaser(11);
        yield return new WaitForSeconds(4f);
        spawnerScript.shootLaser(0);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootLaser(2);
        yield return new WaitForSeconds(4f);
        spawnerScript.shootLaser(6);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(4);
        yield return new WaitForSeconds(5f);

        spawnerScript.shootLaser(1);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(5);
        yield return new WaitForSeconds(4f);

        spawnerScript.shootLaser(8);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(11);
        yield return new WaitForSeconds(4f);

        spawnerScript.shootLaser(0);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(4);
        yield return new WaitForSeconds(5f);
      
        spawnerScript.shootLaser(3);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootLaser(4);
        yield return new WaitForSeconds(6f);

        //EVERYTHING
        //PHASE 1
        spawnerScript.shootBasic(0);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(1);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(2);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(3);
        yield return new WaitForSeconds(5.5f);
        spawnerScript.shootBasic(8);
        yield return new WaitForSeconds(2.5f);
        spawnerScript.shootBasic(9);
        spawnerScript.shootBasic(7);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(10);
        spawnerScript.shootBasic(6);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootBasic(11);
        spawnerScript.shootBasic(5);
        yield return new WaitForSeconds(0.5f);  
        spawnerScript.shootBasic(4);
        yield return new WaitForSeconds(5f);

        //PHASE 2
        spawnerScript.shootFast(4);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(5);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(6);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(7);
        yield return new WaitForSeconds(3.5f);
        spawnerScript.shootFast(11);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootFast(10);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(9);
        spawnerScript.shootFast(3);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(8);
        spawnerScript.shootFast(2);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(1);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(0);
        yield return new WaitForSeconds(5f);

        //everything
        spawnerScript.shootTurret(8);
        spawnerScript.shootTurret(3);
        spawnerScript.shootTurret(7);
        spawnerScript.shootTurret(11);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootLaser(10);
        yield return new WaitForSeconds(2f);
        spawnerScript.shootLaser(6);
        spawnerScript.shootRocket(0);
        spawnerScript.shootRocket(1);
        spawnerScript.shootRocket(2);
        spawnerScript.shootRocket(3);
        yield return new WaitForSeconds(10f);

        spawnerScript.shootTurret(8);
        spawnerScript.shootTurret(11);
        yield return new WaitForSeconds(4f);
        spawnerScript.shootFast(0);
        spawnerScript.shootRocket(6);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(4);
        spawnerScript.shootFast(3);
        yield return new WaitForSeconds(0.5f);
        spawnerScript.shootFast(7);
        spawnerScript.shootRocket(2);
        yield return new WaitForSeconds(10f);

        spawnerScript.shootLaser(8);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(11);
        yield return new WaitForSeconds(4f);
        spawnerScript.shootLaser(4);
        yield return new WaitForSeconds(1f);
        spawnerScript.shootLaser(0);
    }
}

