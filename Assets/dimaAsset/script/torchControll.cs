using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchControll : MonoBehaviour
{
    GameObject player;
    bool tourchInChild;
    new Light light;
    GameObject fire;

    public bool tourchInChildReady;

    private void Start()
    {
        while (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        fire = transform.GetChild(0).GetChild(0).gameObject;
        light=fire.GetComponent<Light>();
    }

    private void Update()
    {
        #region ребенок рядом с факелом и может его взять
        if (!tourchInChild)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 15)
            {
                player.GetComponent<PlayerMove>().torchInChildReady = true;
                player.GetComponent<GrabTorch>().torch = transform;
            }
            else
                player.GetComponent<PlayerMove>().torchInChildReady = false;
        }
        else
        {
            /*light.intensity = Random.Range(2.2f, 2.5f);
            light.color = new Color(1, Random.Range(0f, 0.255f), 0);*/
        }
        #endregion
    }

    public void DisableScr()
    {
        tourchInChild = true;
        fire.SetActive(true);
    }
}
