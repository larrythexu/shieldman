using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider HealthSlider;
	public Image Fill;
    public GameObject Player;
    public GameObject TeleportLocation;
    private Color alphaColor;
    private float timeToFade = 1.0f;
    public GameObject GrayPanel;

	private bool coroutineCalled = false;
    private bool deathCalled = false;
    Color ActiveColor = new Color(1f, 0.5255f, 0.5373f, 1f);
    Color InactiveColor = new Color(1f, 0.1804f, 0f, 1f);


    // Update is called once per frame
    public void Update()
    {
        HealthSlider.value = Globals.Health;
        
        if(Globals.Health <= 20 && !coroutineCalled)
        {
            coroutineCalled = true;
        	StartCoroutine(LowHealth());
        }

        if (Globals.Health <= 0)
        {
            if (!deathCalled)
            {
                deathCalled = true;
                GrayPanel.SetActive(true);
                StartCoroutine(Death());
                StartCoroutine(Lerp_PanelRenderer_Color(GrayPanel.GetComponent<Image>(), 0.7f, 1f));
                StartCoroutine(Lerp_SpriteRenderer_Color(Player.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>(), 1f));
            }
        }

        if(Globals.IsGameOver || Globals.IsPaused)
        {
            GrayPanel.SetActive(false);
        }
    }

    public IEnumerator MinusHealth()
    {
        Fill.color = ActiveColor;
        yield return new WaitForSeconds(.3f);
        Fill.color = InactiveColor;
        yield return new WaitForSeconds(.3f);
        Fill.color = ActiveColor;
        yield return new WaitForSeconds(.3f);
        Fill.color = InactiveColor;
        yield return new WaitForSeconds(.3f);
        Fill.color = InactiveColor;
    }  

    IEnumerator LowHealth()
    {
        while(Globals.Health <= 20)
        {
            Fill.color = ActiveColor;
            yield return new WaitForSeconds(.6f);
            Fill.color = InactiveColor;
            yield return new WaitForSeconds(.6f);
        }
        Fill.color = InactiveColor;
        coroutineCalled = false;
    }

    IEnumerator Death()
    {
        Globals.Dead = true;
        yield return new WaitForSeconds(1f);
        Player.transform.position = TeleportLocation.transform.position;
    }

    private IEnumerator Lerp_SpriteRenderer_Color(SpriteRenderer target_SpriteRender, float lerpDuration)
    {
        Color startLerp = target_SpriteRender.color;
        Color targetLerp = new Color(0f, 0f, 0f, 0f);
        float lerpStart_Time = Time.time;
        float lerpProgress;
        bool lerping = true;
        while (lerping)
        {
            yield return new WaitForEndOfFrame();
            lerpProgress = Time.time - lerpStart_Time;
            if (target_SpriteRender != null)
            {
                target_SpriteRender.color = Color.Lerp(startLerp, targetLerp, lerpProgress / lerpDuration);
            }
            else
            {
                lerping = false;
            }
            
            
            if (lerpProgress >= lerpDuration)
            {
                lerping = false;
            }
        }
        yield break;
    }

    public IEnumerator Lerp_PanelRenderer_Color(Image panel, float alpha, float lerpDuration)
    {
        Color startLerp = panel.color;
        Color targetLerp = new Color(0.4f, 0.4f, 0.4f, alpha);
        float lerpStart_Time = Time.fixedTime;
        float lerpProgress;
        bool lerping = true;
        while (lerping)
        {
            yield return new WaitForEndOfFrame();
            lerpProgress = Time.fixedTime - lerpStart_Time;
            if (panel != null)
            {
                panel.color = Color.Lerp(startLerp, targetLerp, lerpProgress / lerpDuration);
            }
            else
            {
                lerping = false;
            }


            if (lerpProgress >= lerpDuration)
            {
                lerping = false;
            }
        }
        yield break;
    }
}
