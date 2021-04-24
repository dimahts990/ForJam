using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float xAxis, yAxis, moveSpeed;
    [SerializeField]
    Vector3 move;

    private void Update()
    {
        xAxis = Input.GetAxis("Horizontal");
        yAxis = Input.GetAxis("Vertical");

        #region какая то херня
        /*transform.rotation = Quaternion.AngleAxis(rotationLerp, Vector3.up);
        rotationLerp = Mathf.Lerp(0, 360, test);
        if(xAxis!=0 || yAxis != 0)
        {

        }*//*
        if (xAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (xAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (yAxis > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (yAxis < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }*/
        #endregion

        if (xAxis != 0 || yAxis != 0)
        {
            move = new Vector3(xAxis, 0, yAxis);
            StartCoroutine(playerMove());
        }
        else
        {
            move = Vector3.zero;
            StopCoroutine(playerMove());
        }
    }

    IEnumerator playerMove()
    {
        while (true)
        {
            transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if (move != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(move), 5 * Time.deltaTime);
            yield return null;
        }
    }
}
