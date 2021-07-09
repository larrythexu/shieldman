using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelicScript : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject canvas;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Checkpoint"))
        {
            Globals.Win = true;
            Globals.IsGameOver = true;
        }
    }

    void OnDestroy()
    {
        if (canvas != null)
        {
            Globals.IsGameOver = true;
        }
    }
}
