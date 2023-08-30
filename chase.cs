using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{
    public GameObject player;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject pal;
    bool isDead = false;
    //public NavMeshAge
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("TEST" + isDead);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TEST" + isDead);
        isDead = pal.GetComponent<palMove>().dead;
        if (isDead == true)
        {
            Destroy(gameObject);
        }
        //Debug.Log("IS DEAD" + isDead);
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.GetComponent<Collider>().name == "player") && (isDead == false))
        {
            pal.GetComponent<palMove>().chasing = true;
            agent.speed = 3.5f;
            agent.SetDestination(player.transform.position);
            //pal.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            pal.GetComponent<palMove>().chasing = false;
            agent.SetDestination(transform.position);
            agent.speed = 0f;
            //pal.GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
}
