using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ACustomInteractable : XRGrabInteractable
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        // Salvează poziția și rotația inițială a obiectului
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Plasează obiectul în mâna utilizatorului
        AttachToHand(interactor);
    }

    protected override void OnSelectExited(XRBaseInteractor interactor)
    {
        base.OnSelectExited(interactor);

        // Resetarea poziției și rotației obiectului la cele inițiale când este eliberat
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }

    private void AttachToHand(XRBaseInteractor interactor)
    {
        // Asigură-te că obiectul este atașat la mâna utilizatorului
        transform.parent = interactor.transform;

        // Resetarea poziției și rotației relative la mâna utilizatorului
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
