using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    private Animator animator;
    private bool isCollidingWithBarObject = false;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator component not found on children. Make sure it's set up correctly.");
        }
    }

    void Update()
    {
        if (isCollidingWithBarObject)
        {
            animator.SetTrigger("Active");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("BarObject"))
        {
            Debug.Log("Collision with BarObject detected");

            isCollidingWithBarObject = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("BarObject"))
        {
            isCollidingWithBarObject = false;
        }
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
