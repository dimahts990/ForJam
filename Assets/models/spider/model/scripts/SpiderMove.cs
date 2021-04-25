using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 1f;
    float sp=20.0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") > 0)
        {
            sp = 40.0f;
        }
        else
        {
            sp = 20.0f;
        }
        rb.MovePosition(rb.position + transform.forward * moveX * speed/sp);
    }
}
