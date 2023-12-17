using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandController : MonoBehaviour
{
    public float interactionDistance = 10f;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera mainCamera = Camera.main;

            if (mainCamera != null)
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

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
}
