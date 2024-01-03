using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabDistance : XRGrabInteractable
{
    private Vector3 initialPositionOffset;

    protected override void OnSelectEntered(XRBaseInteractor interactor)
    {
        base.OnSelectEntered(interactor);

        // Calculează offset-ul inițial între controller și obiect
        initialPositionOffset = transform.position - interactor.transform.position;

        // Aplică un nou offset pentru a ajusta poziția relativă
        Vector3 newOffset = new Vector3(0.2660041f, -0.247f, 0.4f); // Ajustează această valoare în funcție de necesități
        transform.position = interactor.transform.position + newOffset;
    }
}