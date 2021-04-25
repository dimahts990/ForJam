using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject cam;
    public GameObject pl;
    Vector3 v3,v3_old,v3_new,v3_start;
    public Vector3 speed = new Vector3(1f,1f,1f);
    void Start()
    {
        cam = this.gameObject;
        v3_new = new Vector3(0, 0, 0);
        v3_start = new Vector3(cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }
    void Update()
    {
        if (pl != null)
        {
            v3 = pl.transform.position;
            v3_new.x += (v3.x - v3_old.x) * speed.x * Time.deltaTime;
            v3_new.y += (v3.y - v3_old.y) * speed.y * Time.deltaTime;
            v3_new.z += (v3.z - v3_old.z) * speed.z * Time.deltaTime;
            cam.transform.position = v3_start + v3_new;
            v3_old = v3_new;
        }
    }
}
