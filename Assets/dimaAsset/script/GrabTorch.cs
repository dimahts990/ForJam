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
        yield return new WaitForSeconds(0.73f);
        torch.GetComponent<Rigidbody>().isKinematic = true;
        torch.GetComponent<CapsuleCollider>().enabled = false;
        torch.SetParent(RightHand);
        torch.localPosition = new Vector3(-0.3f, 0.1f, 0);
        torch.localRotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, 75f));
        yield return new WaitForSeconds(0.67f);
        rigActivate = true;
        yield return new WaitForSeconds(1.7f);
        transform.GetComponent<PlayerMove>().ActivateMove();
        torch.GetComponent<torchControll>().DisableScr();
        enabled = false;
    }
}
