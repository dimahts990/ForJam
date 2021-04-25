using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GrabTorch : MonoBehaviour
{
    bool rigActivate;
    Animator anim;

    [SerializeField]
    Rig rig;
    [SerializeField]
    Transform RightHand, controllerHand;

    public Transform torch;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (rigActivate && rig.weight <= 1)
        {
            rig.weight += Time.deltaTime / 3f;
        }
    }

    public void GrabTourchStart()
    {
        StartCoroutine(startGrab());
    }

    private IEnumerator startGrab()
    {
        anim.SetTrigger("grabTorch");
        yield return new WaitForSeconds(2.20f);
        torch.GetComponent<Rigidbody>().isKinematic = true;
        torch.GetComponent<CapsuleCollider>().enabled = false;
        torch.SetParent(RightHand);
        torch.localPosition = new Vector3(-0.2f, 0.2f, 0);
        torch.localRotation = Quaternion.Euler(new Vector3(0.6f, 0.9f, 230.4f));
        yield return new WaitForSeconds(2f);
        rigActivate = true;
        yield return new WaitForSeconds(5.10f);
        transform.GetComponent<PlayerMove>().ActivateMove();
        torch.GetComponent<torchControll>().DisableScr();
        torch.GetChild(0).gameObject.SetActive(true);
        enabled = false;
    }
}
