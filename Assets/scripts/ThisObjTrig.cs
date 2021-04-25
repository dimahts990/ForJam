using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisObjTrig : MonoBehaviour
{
    public bool IsTrig = false;
    public GameObject player;

    void OnTriggerEnter(Collider obj)
    {
        if (obj.gameObject.name == "Player")
        {
            IsTrig = true;
            player = obj.gameObject;
        }
    }
    void OnTriggerExit(Collider obj)
    {
        if (obj.gameObject.name == "Player")
            IsTrig = false;
    }
}
