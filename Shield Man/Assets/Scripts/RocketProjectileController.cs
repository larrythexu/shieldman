using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketProjectileController : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject relic;
    public float moveSpeed;
    Vector3 directionToRelic;
    Vector2 aimDirection;


    // Start is called before the first frame update
    void Start()
    {
        relic = GameObject.Find("Player");
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        moveRocket();
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {

            case "Shield": //potentially change due to different shield types
                Destroy(gameObject);
                Globals.Score += 1;
                Globals.Streak += 1;
                int multiplier = 1 + Globals.Streak / 5;
                Globals.UltCharge += 4 * multiplier;
                break;

            case "EndZone": //to destroy projectiles created if they pass through floor
                Destroy(gameObject);
                break;

            case "Player":
                Globals.IsStunned = true;
                Globals.Health -= 10;
                GameObject HBar = GameObject.Find("HealthBar");
                StartCoroutine(HBar.GetComponent<HealthBar>().MinusHealth());
                Destroy(gameObject);
                Globals.Streak = 0;
                break;
        }

    }

    //make rocket follow player
    void moveRocket()
    {
        //rotation
        transform.LookAt(relic.transform);

        //movement
        if (relic != null)
        {
            directionToRelic = (relic.transform.position - transform.position).normalized;
            aimDirection = new Vector2(directionToRelic.x * moveSpeed, directionToRelic.y * moveSpeed);
            rb.velocity = aimDirection;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }
}
