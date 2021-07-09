using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Transform target;
    public float joystickDeadzone = 0.2f;
    public float angle;
    public bool flipRot = true;
    public float rotationspeed = 15f;

    public AudioSource blockSound;

    void Update()
    {
        transform.position = target.position;
        float x = Input.GetAxis("RightHorizontal");
        float y = Input.GetAxis("RightVertical");
        if ((Mathf.Abs(x) > joystickDeadzone || Mathf.Abs(y) > joystickDeadzone))
        {
            float angle = Mathf.Atan2(x, y) * Mathf.Rad2Deg;
            Quaternion targetRot = Quaternion.Euler(new Vector3(0, 0, angle));
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * rotationspeed);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            blockSound.Play();
        }
    }
}