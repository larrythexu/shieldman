using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUp : MonoBehaviour
{
	//Variables for Ultimate
    public float maxSize;
    public float growFactor;
    public float waitTime;
    // Start is called before the first frame update
    public void Grow()
    {
        StartCoroutine(Scale());
    }

    IEnumerator Scale()
    {
        float timer = 0;

        while(true) // this could also be a condition indicating "alive or dead"
        {
            // we scale all axis, so they will have the same value, 
            // so we can work with a float instead of comparing vectors
            while(maxSize > transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale += new Vector3(0.04f, 0.04f, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
            // reset the timer
 
            yield return new WaitForSeconds(waitTime);
 
            timer = 0;
            while(1 < transform.localScale.x)
            {
                timer += Time.deltaTime;
                transform.localScale -= new Vector3(0.04f, 0.04f, 1) * Time.deltaTime * growFactor;
                yield return null;
            }
 
            timer = 0;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
