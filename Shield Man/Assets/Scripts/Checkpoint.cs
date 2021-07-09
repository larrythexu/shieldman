using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Relic"))
        {
            Globals.Win = true;
            Globals.IsGameOver = true;
        }
    }
}
