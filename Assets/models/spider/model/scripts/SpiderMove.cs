using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : MonoBehaviour
{
    public GameObject col, col2, colider;
    bool isCl = false;
    bool isCl2 = false;
    bool fire = false;
    bool isfire = false;
    Rigidbody rb;
    GameObject player;
    Vector3 targetPoint;
    bool isCol = false;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        isCol = colider.GetComponent<sTrap>().pl_enter;
        isCl = col.GetComponent<ThisObjTrig>().IsTrig;
        isCl2 = col2.GetComponent<ThisObjTrig>().IsTrig;
        if (!isCl)
        {
            if (isCol)
            {
                if (isCl2)
                {
                    player= col2.GetComponent<ThisObjTrig>().player;
                    targetPoint = this.transform.position;
                    Quaternion targetRotation = Quaternion.LookRotation(targetPoint - player.transform.position);
                    //Debug.LogWarning(Mathf.Abs(player.transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y));
                    if(Mathf.Abs(player.transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) < 60f || Mathf.Abs(player.transform.rotation.eulerAngles.y - targetRotation.eulerAngles.y) > 300f)
                    {
                        fire = player.GetComponent<GrabTorch>().TorchDamag;
                    }
                    else
                    {
                        fire = false;
                    }
                }
                if (isCl2 && fire)
                {
                    rb.MovePosition(rb.position + transform.forward * 0.015f);
                }
                else
                {
                    rb.MovePosition(rb.position + -transform.forward * 0.025f);
                }
            }
        }
    }
}
