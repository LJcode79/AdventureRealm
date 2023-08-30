using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    public bool chasing = false;
    bool attacking = false;
    public Animator anim;
    public bool dead = false;
    public GameObject inv;
    public Collider palColl;
    bool chainCollected = false;
    enemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = transform.gameObject.GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("chasing", chasing);
        anim.SetBool("attacking", attacking);
        anim.SetBool("dead", dead);
        if (health.currentHealth <= 0)
        {
            dead = true;
        }
        if ((chasing == true) && (dead == false))
        {
            agent.SetDestination(player.transform.position);
        }

        if (dead == true)
        {
            chasing = false;
            agent.speed = 0f;
            if (chainCollected == false)
            {
                inv.GetComponent<inventorySpace>().addItem(1, "Knight Chain");
                chainCollected = true;
            }
            palColl.enabled = false;
            Destroy(gameObject, 10f);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            attacking = true;
            agent.speed = 0.0f;
        }
        //else if ((other.GetComponent<Collider>().tag == "Weapon") || (other.GetComponent<Collider>().tag == "arrow"))
        //{
           // dead = true;
            //chasing = false;
           // agent.speed = 0.0f;
           // inv.GetComponent<inventorySpace>().addItem(1, "Knight Chain");
           // palColl.enabled = false;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            //chasing = true;
            attacking = false;
            agent.speed = 3.5f;
            //Debug.Log("attack");
        }
    }

    //private void OnCollisionEnter(Collision other)
    //{
        //if ((other.gameObject.tag == "Weapon") || (other.gameObject.tag == "arrow"))
        //{
            //dead = true;
            //chasing = false;
            //agent.speed = 0.0f;
            //inv.GetComponent<inventorySpace>().addItem(1, "Knight Chain");
            //palColl.enabled = false;
        //}
    //}
}
