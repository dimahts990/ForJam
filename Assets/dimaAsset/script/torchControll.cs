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

        #region ??????? ????? ? ??????? ? ????? ??? ?????
        if (!tourchInChild)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 1)
            {
                player.GetComponent<PlayerMove>().torchInChildReady = true;
                player.GetComponent<GrabTorch>().torch = transform;
                player.GetComponent<GrabTorch>().AddLightAndMatTorch(transform.GetChild(0).GetChild(0).GetComponent<Light>(), transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Renderer>().material);
            }
            else
                player.GetComponent<PlayerMove>().torchInChildReady = false;
        }
        else
        {
            light.color = new Color(1, Random.Range(0.23f, 0.25f), 0);
        }
        #endregion
    }

    public void DisableScr()
    {
        tourchInChild = true;
        fire.SetActive(true);
    }
}
