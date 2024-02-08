using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class orders_script : MonoBehaviour
{
    public GameObject order1;
    public GameObject order2;
    public GameObject order1_ingredient1;
    public GameObject order1_ingredient2;
    public GameObject order1_ingredient3;
    public GameObject order2_ingredient1;
    public GameObject order2_ingredient2;
    public GameObject order2_ingredient3;
    public Material material_beer;
    public Material material_jd;
    public Material material_wine;
    public Material material_green;
    public Material material_invizibil;
    public List<string> order1_ingredients = new List<string>();
    public List<string> order2_ingredients = new List<string>();

    public Dictionary<string, Material> drinksAndColors = new Dictionary<string, Material>();

    void Start()
    {
        HideOrder1();
        HideOrder2();

        drinksAndColors.Add("BeerBottle", material_beer);
        drinksAndColors.Add("JDBottle", material_jd);
        drinksAndColors.Add("WineBottle", material_wine);
        drinksAndColors.Add("GreenBottle", material_green);
    }
    public void HideOrder1()
    {
        if (order1 != null)
        {
            order1.SetActive(false);
        }
    }

    public void HideOrder2()
    {
        if (order2 != null)
        {
            order2.SetActive(false);
        }
    }

    public void ShowOrder1()
    {
        if (order1 != null)
        {
            order1.SetActive(true);
        }
    }

    public void ShowOrder2()
    {
        if (order2 != null)
        {
            order2.SetActive(true);
        }
    }

    public int NewOrder()
    {
        // Creează un dicționar pentru a stoca comanda
        Dictionary<string, Material> newOrder = new Dictionary<string, Material>();

        // Alege un număr aleatoriu de băuturi pentru comandă
        int numDrinks = Random.Range(1, 4);

        // Alege băuturile pentru comandă
        for (int i = 0; i < numDrinks; i++)
        {
            // Alege o băutură aleatorie din dicționar
            string drink = drinksAndColors.Keys.ToList()[Random.Range(0, drinksAndColors.Count)];

            // Dacă băutura este deja în comandă, nu o adăuga din nou
            if (!newOrder.ContainsKey(drink))
            {
                newOrder.Add(drink, drinksAndColors[drink]);
            }
        }

        // Dacă order1 nu este afișat, salvează comanda în order1
        if (!order1.activeSelf)
        {
            int j = 0;
            foreach (var item in newOrder)
            {
                if (j == 0) 
                {
                    order1_ingredient1.GetComponent<Renderer>().material = item.Value;
                    order1_ingredients.Add(item.Key);
                }
                if (j == 1) 
                {
                    order1_ingredient2.GetComponent<Renderer>().material = item.Value;
                    order1_ingredients.Add(item.Key);
                }
                if (j == 2) 
                {
                    order1_ingredient3.GetComponent<Renderer>().material = item.Value;
                    order1_ingredients.Add(item.Key);
                }
                j++;
            }
            int numElements = newOrder.Count;
            Debug.Log("order1: " + numElements);
            for (int i = numElements; i < 3; i++)
            {
                if (i == 1) 
                {
                    order1_ingredient2.GetComponent<Renderer>().material = material_invizibil;
                }
                if (i == 2) 
                {
                    order1_ingredient3.GetComponent<Renderer>().material = material_invizibil;
                }
            }
            ShowOrder1();
            return 1;
        }
        else
        {
            int j = 0;
            foreach (var item in newOrder)
            {
                if (j == 0) 
                {
                    order2_ingredient1.GetComponent<Renderer>().material = item.Value;
                    order2_ingredients.Add(item.Key);
                }
                if (j == 1) 
                {
                    order2_ingredient2.GetComponent<Renderer>().material = item.Value;
                    order2_ingredients.Add(item.Key);
                }
                if (j == 2) 
                {
                    order2_ingredient3.GetComponent<Renderer>().material = item.Value;
                    order2_ingredients.Add(item.Key);
                }
                j++;
            }
            int numElements = newOrder.Count;
            Debug.Log("order2: " + numElements);
            for (int i = numElements; i < 3; i++)
            {
                if (i == 1) 
                {
                    order2_ingredient2.GetComponent<Renderer>().material = material_invizibil;
                }
                if (i == 2) 
                {
                    order2_ingredient3.GetComponent<Renderer>().material = material_invizibil;
                }
            }
            ShowOrder2();
            return 2;
        }
    }

}