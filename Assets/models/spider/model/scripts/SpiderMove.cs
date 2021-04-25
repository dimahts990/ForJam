using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{

    Rigidbody rb;
    public GameObject colider;
    bool isCol = false;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        isCol = colider.GetComponent<sTrap>().pl_enter;
        if(isCol)
            rb.MovePosition(rb.position + -transform.forward * 0.025f);
    }
}
