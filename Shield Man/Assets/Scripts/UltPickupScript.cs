using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltPickupScript : MonoBehaviour
{
	private bool full = false;
	private bool coroutineCalled = false;

void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "Player":
                gameObject.transform.position = new Vector3(-1000, -1000, 0);
                if (!coroutineCalled){
                	StartCoroutine(Full());
                }

                break;
        }
    }


	IEnumerator Full()
	{
        int temp = Globals.UltCharge;
		coroutineCalled = true;
		Globals.GodMode = true;
		yield return new WaitForSeconds(3f);
		Globals.GodMode = false;
		coroutineCalled = false;
        Globals.UltCharge = temp;
        gameObject.SetActive(false);

    }
}
