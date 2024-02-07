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
            //if (Input.GetKeyDown(KeyCode.G))
            //{
            animator.SetTrigger("Active");
            //}
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("WineBottle") || collision.collider.CompareTag("GreenBottle") || collision.collider.CompareTag("JDBottle") || collision.collider.CompareTag("BeerBottle") || collision.collider.CompareTag("Shaker") || collision.collider.CompareTag("BarObject"))
        {
            //Debug.Log("Collision with BarObject detected");

            isCollidingWithBarObject = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("WineBottle") || collision.collider.CompareTag("GreenBottle") || collision.collider.CompareTag("JDBottle") || collision.collider.CompareTag("BeerBottle"))
        {
            isCollidingWithBarObject = false;
        }
    }
}