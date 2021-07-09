using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Source: https://www.youtube.com/watch?v=q1gAtOWTs-o

    public Transform[] spawnPoints;
    public GameObject[] projectiles;
    int randomSpawn, randomProjectile;
    public bool autoSpawn = true;
    private static bool _spawnAllowed;
    public static bool spawnAllowed
    {
        get
        {
            return _spawnAllowed;
        }

        set
        {
            //Debug.Log(value);
            _spawnAllowed = value;
        }
    }

    //spawn rate
    public float repeatRate = 1f;


    // Start is called before the first frame update
    void Start()
    {
        spawnAllowed = true;
        if (autoSpawn == true)
        {
            InvokeRepeating("spawnProjectile", 0f, repeatRate);
        }
    }

    void spawnProjectile()
    {
        if (spawnAllowed)
        {
            randomSpawn = Random.Range(0, spawnPoints.Length);
            randomProjectile = Random.Range(0, projectiles.Length);

            Instantiate(projectiles[randomProjectile],
                spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }

    //for master controller use
    public void shootBasic(int spawnPoint) //spawns a basic projectile
    {
        if (spawnAllowed)
        {
            Instantiate(projectiles[0], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
    }

    public void shootFast(int spawnPoint)
    {
        if (spawnAllowed)
        {
            Instantiate(projectiles[1], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
    }

    public void shootLaser(int spawnPoint)
    {
        if (spawnAllowed)
        {
            Instantiate(projectiles[2], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
    }
    public void shootRocket(int spawnPoint)
    {
        if (spawnAllowed)
        {
            Instantiate(projectiles[3], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
    }

    public void shootTurret(int spawnPoint)
    {
        if (spawnAllowed)
        {
            Instantiate(projectiles[4], spawnPoints[spawnPoint].position, Quaternion.identity);
        }
    }
}


