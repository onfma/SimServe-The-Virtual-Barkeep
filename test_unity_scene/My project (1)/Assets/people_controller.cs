using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class people_controller : MonoBehaviour
{
    public orders_script order_script;
    public GameObject Man1;
    public GameObject Man2;
    public GameObject Man3;
    public GameObject Woman1;
    public GameObject Woman2;
    public GameObject Woman3;
    public List<GameObject> clientModels;
    public List<GameObject> currentClients = new List<GameObject>();
    public float rate;
    public GameObject client1 = null;
    public Animator client1_animator = null;
    public GameObject client2 = null;
    public Animator client2_animator = null;
    public int orderC1, orderC2;
    private int clientToDestroy = 0;

    // Start is called before the first frame update
    void Start()
    {
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
        int clientNr = 0; 
        int randomIndex = UnityEngine.Random.Range(0, 6);
        GameObject character = clientModels[randomIndex];
        GameObject newClient = null;
        Animator animator = null;
        if(client1 == null){
            client1 = Instantiate(character, transform.position, Quaternion.identity);
            client1.transform.parent = transform;
            currentClients.Add(client1); 
            client1_animator = client1.GetComponent<Animator>();
            newClient = client1;
            animator = client1_animator; 
            clientNr = 1;
        }
        else{
            if(client2 == null){
                client2 = Instantiate(character, transform.position, Quaternion.identity);
                client2.transform.parent = transform;
                currentClients.Add(client2); 
                client2_animator = client2_animator.GetComponent<Animator>();
                newClient = client2;
                animator = client2_animator; 
                clientNr = 2;
            }
        }
        Vector3 currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;
        yield return new WaitForSeconds(5);
        if (animator != null)
        {
            animator.SetBool("entering", false);
            animator.SetTrigger("start order");
        }
        if(clientNr == 1){
            orderC1 = order_script.NewOrder();
        }
        else{
            orderC2 = order_script.NewOrder();
        }
        
        currentPosition = newClient.transform.position;
        currentPosition.y = 0.1f;
        newClient.transform.position = currentPosition;

        yield return new WaitForSeconds(4);

        animator.SetBool("ordering", false);
        if(clientNr == 1){
            animator.SetTrigger("done ordering right");
        }
        else{
            if(clientNr == 2){
                animator.SetTrigger("done ordering left");
            }
            else{
                animator.SetBool("stay in front", true);
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

    }

   public void GotOrder(List<string> drinks, int id)
    {
        int client;
        Animator anim;
        if (orderC1 == id)
        {
            anim = client1_animator;
            client = 1;
        }
        else
        {
            anim = client2_animator;
            client = 2;
        }

        bool drinkIsGood = order_script.SendOrder(drinks, id);
        anim.SetBool("drunk idle", false);
        anim.SetBool("simple idle", false);

        anim.SetBool("waiting for drink", false);
        anim.SetTrigger("got drink");
        anim.SetTrigger("leaving");

        if (drinkIsGood)
        {
            anim.SetTrigger("liked drink");
        }
        else
        {
            anim.SetTrigger("hated drink");
        }

        if (id == 1)
        {
            order_script.HideOrder1();
        }
        else
        {
            order_script.HideOrder2();
        }

        // Delay destruction of client GameObjects
        clientToDestroy = client;
        Invoke("DestroyClient", 30f);
    }

    // Method to destroy client GameObjects after delay
    private void DestroyClient()
    {
        GameObject client = null;
        switch (clientToDestroy)
        {
            case 1:
                client = client1;
                client1 = null;
                break;
            case 2:
                client = client2;
                client2 = null;
                break;
        }

        if (client != null)
        {
            Destroy(client);
            currentClients.Remove(client);
        }
        clientToDestroy = 0;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

}