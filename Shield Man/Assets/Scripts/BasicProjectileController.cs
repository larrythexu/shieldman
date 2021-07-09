using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BasicProjectileController : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject relic;
    public float moveSpeed;
    Vector3 directionToRelic;
    Vector2 aimDirection;




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

            transform.LookAt(relic.transform);
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = aimDirection;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "PayloadStructureZone":
                Destroy(gameObject);
                break;

            case "Shield": //potentially change due to different shield types
                Destroy(gameObject);
                Globals.Streak += 1;
                int multiplier = 1 + Globals.Streak / 5;
                Globals.UltCharge += 4 * multiplier;
                Globals.Score += 1 * multiplier;
                break;

            case "EndZone": //to destroy projectiles created if they pass through floor
                Destroy(gameObject);
                break;

            case "Relic":
                Spawner.spawnAllowed = false;
                Destroy(gameObject); //projectile disappears
                Destroy(other.gameObject);
                Globals.IsGameOver = true;
                Globals.Streak = 0;
                relic = null;
                break;

            case "Layer1":
                Destroy(gameObject); //projectile disappears
                other.gameObject.SetActive(false);
                Globals.Streak = 0;
                break;

            case "Layer2":
                Destroy(gameObject); //projectile disappears
                other.gameObject.SetActive(false);
                Globals.Streak = 0;
                break;

            case "Player":
                Globals.IsStunned = true;
                Globals.Health -= 10;
                GameObject HBar = GameObject.Find("HealthBar");
                StartCoroutine(HBar.GetComponent<HealthBar>().MinusHealth());
                Destroy(gameObject);
                Globals.Streak = 0;
                break;

                /* PROTECTIVE LAYERS AROUND RELIC */
                /*
                case "Layer2W":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer2NW":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer2N":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer2NE":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer2E":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1W":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NWW":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NW":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NNW":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1N":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NNE":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NE":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1NEE":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;

                case "Layer1E":
                    Destroy(gameObject); //projectile disappears
                    Destroy(other.gameObject);
                    relic = null;
                    break;
                    */

                //case "Player" - make stun action
        }
    }
}
