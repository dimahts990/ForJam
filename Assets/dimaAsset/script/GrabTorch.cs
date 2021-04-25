using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class GrabTorch : MonoBehaviour
{
    public bool TorchDamag,debug;

    [ColorUsage(true, true)]
    public Color torchOff, torchOn;


    bool rigActivate, torchInChild;
    float activatedTorch;
    Animator anim;
    Vector3 offTorhcPos = new Vector3(0.3f, 1.0f, 0.3f), onTorhcPos = new Vector3(-0.1f, 1.6f, 1.1f);
    Quaternion offTorhcRot = new Quaternion(0.5f, -0.5f, -0.3f, 0.6f), onTorhcRot = new Quaternion(0.7f, -0.3f, -0.5f, 0.4f);
    Material fireMat;
    Light fireLight;
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
        if (!torchInChild)
        {
            if (rigActivate && rig.weight <= 1)
            {
                rig.weight += Time.deltaTime / 3f;
            }
        }
        else
        {
            controllerHand.localPosition = Vector3.Lerp(offTorhcPos, onTorhcPos, activatedTorch);
            controllerHand.localRotation = Quaternion.Lerp(offTorhcRot, onTorhcRot, activatedTorch);
            if(fireMat!=null && fireLight != null)
            {
                fireMat.SetColor("_EmissionColor", Color.Lerp(torchOff, torchOn, activatedTorch));
                fireLight.intensity = Mathf.Lerp(Random.Range(2.2f, 2.25f), Random.Range(5.5f, 6.1f), activatedTorch);
            }
        }
        if (TorchDamag)
        {
            if (activatedTorch <= 1)
                activatedTorch += Time.deltaTime;
        }
        else
        {
            if (activatedTorch >= 0)
                activatedTorch -= Time.deltaTime;
        }
    }

    public void GrabTourchStart()
    {
        if(!torchInChild)
            StartCoroutine(startGrab());
    }

    public void AddLightAndMatTorch(Light l, Material m)
    {
        fireLight = l;
        fireMat = m;
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
        torchInChild = true;
    }
}
