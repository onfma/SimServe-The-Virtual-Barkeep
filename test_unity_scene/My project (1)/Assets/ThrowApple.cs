using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowApple : MonoBehaviour
{
    public float throwForce = 30f;
    public GameObject apple;

    private bool isThrowing = false;

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            isThrowing = true;
        }

        if (Mouse.current.leftButton.wasReleasedThisFrame && isThrowing)
        {
            ThrowTheApple(throwForce);
            isThrowing = false;
        }
    }

    void ThrowTheApple(float throwForce)
    {
        GameObject appleObject = Instantiate(apple, transform.position, Quaternion.Euler(0, 0, 0));
        Rigidbody appleRigidbody = appleObject.GetComponent<Rigidbody>();
        appleRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
