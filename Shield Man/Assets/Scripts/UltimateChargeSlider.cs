using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UltimateChargeSlider : MonoBehaviour
{
    public Slider UltimateCharge;
    public Image Fill;

    private bool coroutineCalled = false;
    Color ActiveColor = new Color(1f, 0f, 0.7216f, 1f);
    Color InactiveColor = new Color(1f, 0.4275f, 0.7216f, 1f);

    // Update is called once per frame
    void Update()
    {
        UltimateCharge.value = Globals.UltCharge;
        if(UltimateCharge.value >= 100 && !coroutineCalled)
        {
            StartCoroutine(ReadyFlash());
            coroutineCalled = true;
        }
    }

    IEnumerator ReadyFlash()
    {
        while(UltimateCharge.value >= 100)
        {
            Fill.color = ActiveColor;
            yield return new WaitForSeconds(0.5f);
            Fill.color = InactiveColor;
            yield return new WaitForSeconds(0.5f);
        }
        Fill.color = InactiveColor;
        coroutineCalled = false;
    }  
}
