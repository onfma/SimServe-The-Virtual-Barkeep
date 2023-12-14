using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    public Camera externalCamera;
    public float interactionDistance = 10f;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = externalCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                Debug.Log("Hit object: " + hit.collider.gameObject.name);
                Debug.Log("Hit object tag: " + hit.collider.tag);

                if (hit.collider.CompareTag("BarObject"))
                {
                    animator.SetTrigger("Active");
                }
                else
                {
                    Debug.Log("Hit object with incorrect tag.");
                }
            }
        }
    }
}
