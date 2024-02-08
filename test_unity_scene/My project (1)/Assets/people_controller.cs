using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_controller : MonoBehaviour
{
    public GameObject Man1;
    public GameObject Man2;
    public GameObject Man3;
    public GameObject Woman1;
    public GameObject Woman2;
    public GameObject Woman3;
    public List<GameObject> clientModels;
    public List<GameObject> currentClients = new List<GameObject>();
    public float rate;
    public bool right, left;

    // Start is called before the first frame update
    void Start()
    {
        right = false;
        left = false;
        clientModels = new List<GameObject>(){
            Man1, 
            Man2,
            Man3,
            Woman1,
            Woman2,
            Woman3
        };
        rate = 5;
        StartCoroutine(SpawnClients());
    }

    IEnumerator SpawnClients()
    {
        while (true)
        {
            if (currentClients.Count < 3)
            {
                StartCoroutine(CreateNewClient());
                yield return new WaitForSeconds(rate);
            }
            else
            {
                yield return null;
            }
        }
    }
    
    IEnumerator CreateNewClient()
    {
        int randomIndex = UnityEngine.Random.Range(0, 6);
        GameObject character = clientModels[randomIndex];
        GameObject newClient = Instantiate(character, transform.position, Quaternion.identity);
        newClient.transform.parent = transform;
        currentClients.Add(newClient); 
        string gone = "";

        Vector3 currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;

        yield return new WaitForSeconds(5);

        Animator animator = newClient.GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("entering", false);
            animator.SetTrigger("start order");
        }

        currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;

        yield return new WaitForSeconds(4);

        animator.SetBool("ordering", false);
        if(right == false){
            animator.SetTrigger("done ordering right");
            right = true;
            gone = "right";
        }
        else{
            if(left == false){
                animator.SetTrigger("done ordering left");
                left = true;
                gone = "left";
            }
            else{
                animator.SetBool("stay in front", true);
                gone = "stayed";
            }
        }

        currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;

        int random = UnityEngine.Random.Range(0, 10);
        if(random < 8){
            animator.SetTrigger("simple idle");
        }
        else{
            animator.SetTrigger("drunk idle");
        }

        currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;


        yield return new WaitForSeconds(5);
        animator.SetBool("drunk idle", false);
        animator.SetBool("simple idle", false);
        // in loc de yeild wait for drink delivery
        // while distanta dintre personaj si un pahar < min distance
        
        if (animator != null)
        {
            animator.SetBool("waiting for drink", false);
            animator.SetTrigger("got drink");
            //in loc de setat liked drink det scorul bauturii cu pos de "hated drink"
            animator.SetTrigger("liked drink");
            animator.SetTrigger("leaving");

        }
        yield return new WaitForSeconds(30);
        if(gone == "left"){
            left = false;
        }
        else
        {
            if(gone == "right"){
                right = false;
            }
            else{
                animator.SetBool("stay in front", false);
            }
        }
        
        Destroy(newClient);

        currentClients.Remove(newClient);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}