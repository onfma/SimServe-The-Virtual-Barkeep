using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabObject : MonoBehaviour
{
    public XRGrabInteractable grabInteractable; // obiectul care poate fi apucat
    public Transform handAnchor; // obiectul-ancoră

    private void OnEnable()
    {
        grabInteractable.onSelectEntered.AddListener(SetParent);
        grabInteractable.onSelectExited.AddListener(RemoveParent);
    }

    private void OnDisable()
    {
        grabInteractable.onSelectEntered.RemoveListener(SetParent);
        grabInteractable.onSelectExited.RemoveListener(RemoveParent);
    }

    private void SetParent(XRBaseInteractor interactor)
    {
        grabInteractable.transform.SetParent(handAnchor);
    }

    private void RemoveParent(XRBaseInteractor interactor)
    {
        grabInteractable.transform.SetParent(null);
    }
}