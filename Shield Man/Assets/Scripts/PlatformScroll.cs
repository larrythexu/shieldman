using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScroll : MonoBehaviour
{
    public float moveSpeed = -3f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
  
    }
}
