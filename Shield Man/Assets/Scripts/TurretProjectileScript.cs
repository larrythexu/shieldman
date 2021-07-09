using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretProjectileScript : MonoBehaviour
{
    Rigidbody2D rb;
    GameObject relic;
    public float moveSpeed;
    Vector3 directionToRelic;
    Vector2 aimDirection;

    //turret placement
    public float turretDisplacement;
    public float sendTime;

    // Start is called before the first frame update
    void Start()
    {
        relic = GameObject.Find("Payload");
        rb = GetComponent<Rigidbody2D>();

        //create projectile's attributes
        if (relic != null)
        {
            directionToRelic = (relic.transform.position - transform.position).normalized;
            aimDirection = new Vector2(directionToRelic.x * moveSpeed, directionToRelic.y * moveSpeed);

            //rotates sprite's direction
            //source: https://answers.unity.com/questions/1108867/how-do-i-point-towards-my-gameobject-in-2d.html
            Quaternion rotation = Quaternion.LookRotation(relic.transform.position - transform.position,
                transform.TransformDirection(Vector3.up));
            transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        deploy();
    }

    void deploy()
    {
        //send turret into direction
        rb.velocity = aimDirection * turretDisplacement;
        StartCoroutine(deployStop(sendTime));
    }

    IEnumerator deployStop(float time)
    {
        yield return new WaitForSeconds(time);

        rb.velocity = Vector3.zero;
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
}

