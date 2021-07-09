using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthPickup : MonoBehaviour
{
    public AudioSource pickupSound;
    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                pickupSound.Play();
            	Globals.Health = 100;
                Destroy(this.gameObject);
                break;
        }
    }
}
