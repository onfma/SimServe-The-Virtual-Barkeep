using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ApplyForce : MonoBehaviour
{
    private XRGrabInteractable interactable;
    public float throwForce = 50f;
    void Start()
    {
        interactable = GetComponent<XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        throwForce = 0f;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Vector3 throwDirection = args.interactorObject.transform.forward;
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }

    }
}
