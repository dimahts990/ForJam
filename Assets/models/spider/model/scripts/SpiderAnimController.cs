using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimController : MonoBehaviour
{
    public GameObject col;
    public AudioClip walk, scream;
    public AudioSource AS;
    bool isCl = false;
    public Animator anim;
    long schetchik = 0;
    bool first = true;
    bool first2 = true;
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
                if (first)
                {
                    AS.volume = 1f;
                    AS.PlayOneShot(scream);
                    first = false;
                }
                anim.SetFloat("Wspeed", speed * 20f);
                if (fwd())
                {
                    if (schetchik == 0)
                    {
                        AS.PlayOneShot(walk);
                    }
                    AS.pitch = Mathf.Clamp(speed * 20f + Random.Range(-0.2f, 0.2f), 0.5f, 1.5f);
                    AS.volume = 1f;
                    anim.SetBool("isActive", true);
                    anim.SetBool("isFire", false);
                    schetchik++;
                    if (schetchik >= 40)
                        schetchik = 0;
                }
                else
                {
                    if (schetchik == 0)
                    {
                        AS.PlayOneShot(walk);
                    }
                    AS.pitch = Mathf.Clamp(speed * 20f + Random.Range(-0.2f, 0.2f),0.5f,1.5f);
                    AS.volume = 0.6f;
                    anim.SetBool("isFire", true);
                    schetchik++;
                    if (schetchik >= 40)
                        schetchik = 0;
                }
            }
            if (speed <= 0.00001f)
            {
                anim.SetBool("isFire", false);
                anim.SetBool("isActive", false);
                anim.SetFloat("Wspeed", 1.0f);
                first = true;
            }
        }
        else
        {                                                                                                      
            anim.SetBool("isAtt", true);
            AS.volume = 1f;
            AS.pitch = 1f;
            if(first2)
            AS.PlayOneShot(scream);
            first2 = false;
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
