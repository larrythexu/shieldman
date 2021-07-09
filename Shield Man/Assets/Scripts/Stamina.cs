using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Stamina : MonoBehaviour
{
	//public Slider CurStamina;
	//public Image Fill;
    public GameObject Shield;

    private bool coroutineUpCalled = false;

    private bool coroutineDownCalled = false;

    // Update is called once per frame
    void Update()
    {
    	//CurStamina.value = Globals.Stamina;
        Shield.transform.GetChild(0).gameObject.transform.localScale = new Vector3(0.1f, 0.1f+Globals.Stamina / 1000f, 1f);

        if (Shield.activeSelf == true && !coroutineDownCalled && !coroutineUpCalled){
    		coroutineDownCalled = true;
    		StartCoroutine(StaminaDown());
    	}
    	else{
    		if(!coroutineUpCalled && !coroutineDownCalled){
    			coroutineUpCalled = true;
    			StartCoroutine(StaminaUp());
    		}
    		
    	}
    	
    }

    IEnumerator StaminaUp()
    {
    	yield return new WaitForSeconds(0.05f);
    	if(Globals.Stamina < 100f){
    		Globals.Stamina += 3.0f;
    	}
    	coroutineUpCalled = false;
    }

    IEnumerator StaminaDown()
    {
		yield return new WaitForSeconds(0.05f);
    	if(Globals.Stamina > 0f){
    		Globals.Stamina -= 1.5f;
    	}
    	coroutineDownCalled = false;
    }
}
