using System.Collections.Generic;
using UnityEngine;

public class DrinkScript : MonoBehaviour
{
    private List<string> drinks = new List<string>();
    public Material newMaterial;
    private Rigidbody rb;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("WineBottle") || collision.collider.CompareTag("GreenBottle") || collision.collider.CompareTag("JDBottle") || collision.collider.CompareTag("BeerBottle"))
        {
            string drinkName = collision.collider.tag;
            Debug.Log("Collided with: " + drinkName);
            if (!drinks.Contains(drinkName))
            {
                drinks.Add(drinkName);
            }
        }

        if (collision.collider.CompareTag("BarObject") && drinks.Count > 0)
        { 
            Renderer renderer = collision.gameObject.GetComponent<Renderer>();
            glass_script glass_script = collision.gameObject.GetComponent<glass_script>();
            glass_script.AddDrink(drinks);
            if (renderer != null)
            {
                renderer.material = newMaterial;
            }
            drinks = new List<string>();
        }

        rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
            Invoke("ReluareFizica", 1);
        }
    }

    void ReluareFizica()
    {
        if (rb != null)
        {
            rb.isKinematic = false; // Reluarea efectului fizicii asupra obiectului
        }
    }
    public void DisplayContents()
    {
        foreach (string drink in drinks)
        {
            Debug.Log("Shaker contains " + drink);
        }
    }
}
