using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sTrap : MonoBehaviour
{
    public Rigidbody spider;
    public bool pl_enter = false;
    GameObject player;

    void Start()
    {
        Debug.Log(this.gameObject.name);
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "Player")
        {
            pl_enter = true;
            player = obj.gameObject;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.name == "Player")
            pl_enter = false;
    }

    void Update()
    {
        if (pl_enter)
        {
            if (player != null)
            {
                Vector3 targetPoint = player.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(targetPoint - spider.transform.position);
                targetRotation = Quaternion.Euler(targetRotation.eulerAngles.x, targetRotation.eulerAngles.y + 180, targetRotation.eulerAngles.z);
                spider.transform.rotation = targetRotation;
            }
        }
    }
}
