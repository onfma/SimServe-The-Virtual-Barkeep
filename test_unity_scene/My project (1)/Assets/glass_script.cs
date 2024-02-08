using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glass_script : MonoBehaviour
{
    public people_controller peopleCountroller;
    public orders_script orderScript;
    public List<string> drinks = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddDrink(List<string> shaker_drinks){
        drinks = shaker_drinks;
    }
    

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter(Collision collision){
        if(collision.collider.CompareTag("RightHand") && drinks.Count != 0){
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
            {
                peopleCountroller.GotOrder(drinks, 1);

                // Debug.Log("1 key is pressed");
                // foreach (var d in drinks){
                //     Debug.Log(d);
                // }

            }

            if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
            {
                peopleCountroller.GotOrder(drinks, 2);
                // Debug.Log("2 key is pressed");
            }
        }
    }
}
