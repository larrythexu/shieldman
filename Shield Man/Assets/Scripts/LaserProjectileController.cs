using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LaserProjectileController : MonoBehaviour
{

    Rigidbody2D rb;
    GameObject relic;
    public float moveSpeed;
    private int count;
    Vector3 directionToRelic;
    Vector2 aimDirection;

    //laser
    public LineRenderer lineRenderer;
    private Transform lineSpawn;
    private bool laserDone;
    private bool shotFired;

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

        //laser
        //Vector2 laserDirection = new Vector2(directionToRelic.x * -1, directionToRelic.y * -1);
        lineSpawn = transform.GetChild(1);
        //RaycastHit2D hitInfo = Physics2D.Raycast(lineSpawn.position, aimDirection);

        lineRenderer.SetPosition(0, lineSpawn.position);
        lineRenderer.SetPosition(1, relic.transform.position);
        lineRenderer.enabled = true;

        laserDone = false;
        shotFired = false;

        /*
        if (hitInfo)
        {
            //TEST
            lineSpawn.position = new Vector3(lineSpawn.position.x, lineSpawn.position.y + 1.1f);

            //show trace
            lineRenderer.SetPosition(0, lineSpawn.position);
            lineRenderer.SetPosition(1, hitInfo.point);
            lineRenderer.enabled = true;

            laserDone = false;
        } */

    }

    // Update is called once per frame
    void Update()
    {
        if (shotFired == false)
        {
            StartCoroutine(FireShot());
        }

        if (laserDone)
        {
            lineRenderer.enabled = false;
        }
    }

    //IEnumerator for delay
    IEnumerator FireShot()
    {
        yield return new WaitForSeconds(2.5f);
        //change look of line - warning
        lineRenderer.startColor = Color.magenta;
        lineRenderer.endColor = Color.magenta;
        lineRenderer.startWidth = 0.20f;
        lineRenderer.endWidth = 0.20f;

        yield return new WaitForSeconds(0.5f);

        rb.AddForce(aimDirection);
        shotFired = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        switch (other.gameObject.tag)
        {
            case "PayloadStructureZone":
                Destroy(gameObject);
                laserDone = true;
                break;

            case "Shield": //potentially change due to different shield types
                Destroy(gameObject);
                Globals.Score += 1;
                Globals.Streak += 1;
                int multiplier = 1 + Globals.Streak / 5;
                Globals.UltCharge += 4 * multiplier;
                break;

            case "EndZone": //to destroy projectiles created if they pass through floor
                laserDone = true;
                Destroy(gameObject);
                break;

            case "Relic":
                Spawner.spawnAllowed = false;
                Destroy(other.gameObject);
                Globals.IsGameOver = true;
                Globals.Streak = 0;
                relic = null;
                Destroy(gameObject); //projectile disappears
                break;

            case "Layer1":
                other.gameObject.SetActive(false);
                Globals.Streak = 0;
                Destroy(gameObject); //projectile disappears
                break;

            case "Layer2":
                other.gameObject.SetActive(false);
                Globals.Streak = 0;
                Destroy(gameObject); //projectile disappears
                break;

            case "Player":
                Globals.IsStunned = true;
                Globals.Health -= 10;
                GameObject HBar = GameObject.Find("HealthBar");
                StartCoroutine(HBar.GetComponent<HealthBar>().MinusHealth());
                Globals.Streak = 0;
                Destroy(gameObject);
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
