using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //Movement variables
    public float speed = 0.2f;
    public float jump = 1;
    public float jumpVelocity = 13f;
    public float fallVelocity = -15f;
    private bool isGrounded; //marks when character is touching ground
    public float dashSpeed = 5f;
    //JUMP TIMER
    private float canJump = 0f;
    //DASH TIMER
    private float canDash = 0f;

    public GameObject Flash;

    //Controller variables
    public string charX = "LeftHorizontal";
    public string charY = "LeftVertical";
    public string jumpName = "AButton";
    public string shieldX = "RightHorizontal";
    public string shieldY = "RightVertical";
    public float joystickDeadzone = 0.2f;

    //UI Text elements
    public Text CountText;
    //public Text UltimateText;
    public Text StreakText;

    public GameObject Shield;
    public GameObject SubShield;

    public GameObject HealthBar;
    public GameObject GrayPanel;
    bool coroutinePanel = false;

    private Rigidbody2D rb;
    public float thrust = 3000f; //for ultimate speed

    private bool coroutineCalled = false;


    //audio
    public AudioSource jumpAudio;
    public AudioSource hitAudio;

    //particles
    public ParticleSystem dashPS;
    //public ParticleSystem blockPS;

    private void Start()
    {
        Globals.Health = 100;
        Globals.Dead = false;
        Globals.Stamina = 100f;
        Globals.Score = 0;
        Globals.IsGameOver = false;
        Globals.IsPaused = false;
        Globals.IsStunned = false;
        Globals.UltCharge = 0;
        Globals.Win = false;
        rb = GetComponent<Rigidbody2D>();
        GrayPanel = GameObject.Find("GrayPanel");
        HealthBar = GameObject.Find("HealthBar");
        Flash = this.transform.GetChild(1).gameObject;

        CountText.text = "Score: 0";
//        UltimateText.text = "Charge: 0%";
        StreakText.text = "Streak: 0";

        dashPS = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        //Player stat updates
        CountText.text = "Score: " + Globals.Score.ToString();
//        UltimateText.text = "Charge : " + Globals.UltCharge.ToString() + "%";
        StreakText.text = "Streak: " + Globals.Streak.ToString();

        //Quit to main menu
        if (!(Globals.IsPaused || Globals.IsGameOver || Globals.Dead))
        {
            //Horizontal Movement
            if (Mathf.Abs(Input.GetAxis(charX)) >= joystickDeadzone)
            {
                transform.parent = null;
                transform.position += transform.right * Input.GetAxis(charX) * speed;
            }

            //Jump Command
            if ((Input.GetKeyDown("joystick button 0") || Input.GetAxis(charY) > (joystickDeadzone + 0.3f)) && isGrounded && Time.time > canJump)
            {
                jumpAudio.Play();
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
                canJump = Time.time + 0.8f; //landing lag timer
            }

            //Dash Command
            if (Input.GetKeyDown("joystick button 5") && Time.time > canDash) //right bumper - include timer
            {
                StartCoroutine(DashMove(Flash.GetComponent<SpriteRenderer>(), 0.5f));
                canDash = Time.time + 1.5f;
            }

            if (Globals.UltCharge >= 100 || Globals.GodMode)
            {
                Globals.UltCharge = 100;
                if (Input.GetKeyDown("joystick button 4"))
                {
                    GameObject Ultimate = Instantiate(SubShield, SubShield.transform.position, SubShield.transform.rotation);
                    Vector3 forward = (SubShield.transform.position - transform.position).normalized;
                    Vector2 aimDirection = new Vector2(forward.x * thrust, forward.y * thrust);
                    Rigidbody2D UltimateRB = Ultimate.AddComponent<Rigidbody2D>();
                    UltimateRB.gravityScale = 0;
                    UltimateRB.AddForce(aimDirection * thrust);
                    Ultimate.GetComponent<ScaleUp>().Grow();
                    //INSTANTIATE SHIELD OBJECT AND SEND IT OUT

                    if(!Globals.GodMode)
                        Globals.UltCharge  = 0;

                }
            }

            //Fast Falling
            if (Input.GetAxis(charY) < (-1 * (joystickDeadzone + 0.3f)) && !(isGrounded))
            {
                rb.velocity = new Vector2(rb.velocity.x, fallVelocity);
            }

            //flip character animation
            if (Input.GetAxis(charX) < 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x = -1.0f;
                transform.localScale = newScale;
            }
            else if (Input.GetAxis(charX) > 0)
            {
                Vector3 newScale = transform.localScale;
                newScale.x = 1.0f;
                transform.localScale = newScale;
            }
        }

        //Character stun condition
        if(Globals.IsStunned && !coroutineCalled){
            coroutineCalled = true;
            StartCoroutine(WaitForStunToEnd());
            StartCoroutine(StunFlash());
        }

    }

    void FixedUpdate()
    {
        if((Mathf.Abs(Input.GetAxis(shieldX)) >= joystickDeadzone || Mathf.Abs(Input.GetAxis(shieldY)) >= joystickDeadzone))
        {
            Shield.SetActive(true);
        }

        else
        {
            Shield.SetActive(false);
        }
    }

    //Ground collision management
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground") )
        {
            isGrounded = true;
            transform.parent = other.gameObject.transform;
        }

        if (other.gameObject.CompareTag("DeathCollider"))
        {
            Globals.Health = 0;
        }

        if (other.gameObject.CompareTag("Projectile"))
        {
            hitAudio.Play();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            transform.parent = other.gameObject.transform;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            transform.parent = null;
            isGrounded = false;
        }
    }



    IEnumerator WaitForStunToEnd() {
         // Wait a frame
         yield return null;
         // Wait 1 second
         yield return new WaitForSeconds(1f);
         Globals.IsStunned = false;
         coroutineCalled = false;
    }

    IEnumerator StunFlash()
    {
        while (Globals.IsStunned)
        {
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0, 1);
            yield return new WaitForSeconds(0.3f);
            this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            yield return new WaitForSeconds(0.3f);
        }
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }    

    //Dash Manager
    IEnumerator DashMove(SpriteRenderer target_SpriteRender, float lerpDuration)
    {
        Color startLerp = target_SpriteRender.color;
        Color targetLerp = new Color(1f, 1f, 1f, 0f);
        float lerpStart_Time = Time.time;
        float lerpProgress;
        bool lerping = true;
        

        speed += dashSpeed;
        yield return new WaitForSeconds(0.008f);
        speed -= dashSpeed;

        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;

        Flash.SetActive(true);
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
       
        Flash.SetActive(false);
        target_SpriteRender.color = startLerp;

        //character color change
        //this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        yield return new WaitForSeconds(1f);
        this.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        yield break;
    }
}

