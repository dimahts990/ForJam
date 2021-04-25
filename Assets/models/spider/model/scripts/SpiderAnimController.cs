using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimController : MonoBehaviour
{
    public GameObject col;
    bool isCl = false;
    public Animator anim;
    Rigidbody rb;
    Vector3 v3;
    void Start()
    {
        anim.SetFloat("Wspeed", 1.0f);
        rb = this.GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        isCl = col.GetComponent<ThisObjTrig>().IsTrig;
        if (!isCl)
        {
            float speed = (rb.position - v3).magnitude;
            if (speed >= 0.00001f)
            {
                anim.SetFloat("Wspeed", speed * 20f);
                if (fwd())
                {
                    anim.SetBool("isActive", true);
                    anim.SetBool("isFire", false);
                }
                else
                {
                    anim.SetBool("isFire", true);
                }
            }
            if (speed <= 0.00001f)
            {
                anim.SetBool("isFire", false);
                anim.SetBool("isActive", false);
                anim.SetFloat("Wspeed", 1.0f);
            }
        }
        else
        {                                                                                                      
            anim.SetBool("isAtt", true);
            GameObject pl = col.GetComponent<ThisObjTrig>().player;                                                                  //////////   ялепж    /////////
            Destroy(pl);
        }
        v3 = rb.position;
    }
    bool fwd()
    {
        Vector3 nv3 = rb.position - v3;
        if (nv3.z <= -0.0000001f && (rb.rotation.eulerAngles.y > 315f || rb.rotation.eulerAngles.y <= 45f)){
            return true;
        }
        if (nv3.x <= -0.0000001f && (rb.rotation.eulerAngles.y > 45f && rb.rotation.eulerAngles.y <= 135f))
        {
            return true;
        }
        if (nv3.z >= 0.0000001f && (rb.rotation.eulerAngles.y > 135f && rb.rotation.eulerAngles.y <= 225f))
        {
            return true;
        }
        if (nv3.x >= 0.0000001f && (rb.rotation.eulerAngles.y > 225f && rb.rotation.eulerAngles.y <= 315f))
        {
            return true;
        }
        return false;
    }
}
