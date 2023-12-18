using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        // Asigură-te că avem componenta XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Adaugă funcții de gestionare a apucării și eliberării
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Logică pentru apucarea obiectului
        Debug.Log("Obiect apucat!");
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Logică pentru eliberarea obiectului
        Debug.Log("Obiect eliberat!");
    }
}


// using UnityEngine;
// using UnityEngine.XR.Interaction.Toolkit;
// using UnityEngine.InputSystem;

// public class HandController : MonoBehaviour
// {
//     public Camera externalCamera;
//     public float interactionDistance = 10f;
//     Animator animator;
//     private XRGrabInteractable grabInteractable;

//     void Start()
//     {
//         animator = GetComponent<Animator>();
//         grabInteractable = GetComponent<XRGrabInteractable>();

//         // Verifică dacă grabInteractable este nul înainte de a adăuga ascultători
//         if (grabInteractable != null)
//         {
//             grabInteractable.onSelectEntered.AddListener(OnGrab);
//             grabInteractable.onSelectExited.AddListener(OnRelease);
//         }
//         else
//         {
//             Debug.LogError("Componenta XRGrabInteractable nu a fost găsită pe acest obiect.");
//         }
//     }


//     void Update()
//     {
//         // Logică pentru apucarea obiectului cu mouse
//         if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
//         {
//             Ray ray = externalCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
//             RaycastHit hit;

//             if (Physics.Raycast(ray, out hit, interactionDistance))
//             {
//                 Debug.Log("Hit object: " + hit.collider.gameObject.name);
//                 Debug.Log("Hit object tag: " + hit.collider.tag);

//                 if (hit.collider.CompareTag("BarObject"))
//                 {
//                     animator.SetTrigger("Active");
//                 }
//                 else
//                 {
//                     Debug.Log("Hit object with incorrect tag.");
//                 }
//             }
//         }
//     }

//     // Funcție apelată când obiectul este apucat
//     private void OnGrab(XRBaseInteractor interactor)
//     {
//         Debug.Log("Obiect apucat cu controller-ul!");
//     }

//     // Funcție apelată când obiectul este eliberat
//     private void OnRelease(XRBaseInteractor interactor)
//     {
//         Debug.Log("Obiect eliberat cu controller-ul!");
//     }
// }
