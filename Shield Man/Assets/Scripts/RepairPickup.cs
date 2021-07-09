using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairPickup : MonoBehaviour
{
	public int size = 14;
    public GameObject[] payloadArr;
    private bool coroutineCalled = false;



    void Start()
    {
	    GameObject Layer1W = GameObject.Find("Layer1W");
	    GameObject Layer1NW = GameObject.Find("Layer1NW");
	    GameObject Layer1N = GameObject.Find("Layer1N");
	    GameObject Layer1NE = GameObject.Find("Layer1NE");
	    GameObject Layer1E = GameObject.Find("Layer1E");
	    GameObject Layer1NWW = GameObject.Find("Layer1NWW");
	    GameObject Layer1NNW = GameObject.Find("Layer1NNW");
	    GameObject Layer1NNE = GameObject.Find("Layer1NNE");
	    GameObject Layer1NEE = GameObject.Find("Layer1NEE");
	    GameObject Layer2W = GameObject.Find("Layer2W");
	    GameObject Layer2NW = GameObject.Find("Layer2NW");
	    GameObject Layer2N = GameObject.Find("Layer2N");
	    GameObject Layer2E = GameObject.Find("Layer2E");
	    GameObject Layer2NE = GameObject.Find("Layer2NE");
        
        payloadArr = new GameObject[size];
        
        payloadArr[0] = Layer2W; 
        payloadArr[1] = Layer2NW;
        payloadArr[2] = Layer2N;
        payloadArr[3] = Layer2NE;
        payloadArr[4] = Layer2E;
        payloadArr[5] = Layer1W;
        payloadArr[6] = Layer1NWW;
        payloadArr[7] = Layer1NW;
        payloadArr[8] = Layer1NNW;
        payloadArr[9] = Layer1N;
        payloadArr[10] = Layer1NNE;
        payloadArr[11] = Layer1NE;
        payloadArr[12] = Layer1NEE;
        payloadArr[13] = Layer1E;

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                gameObject.transform.position = new Vector3(-1000, -1000, 0);
                
                if(!coroutineCalled){
                    StartCoroutine(Repair());
                }

                break;
        }
    }

    IEnumerator Repair()
    {
        coroutineCalled = true;
    	for(int i = 0; i < size; i++)
        {
        	if(!payloadArr[i].activeSelf)
        	{
        		payloadArr[i].SetActive(true);
        		yield return new WaitForSeconds(.2f);
        	}
        }
        
        coroutineCalled = false;
    }
}
