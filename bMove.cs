using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    bool attacking = false;
    public Animator anim;
    public bool dead = false;
    public Collider palColl;
    public GameObject inv;
    bool lumCollected = false;
    enemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = transform.gameObject.GetComponent<enemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("attacking", attacking);
        anim.SetBool("dead", dead);
        if (health.currentHealth <= 0)
        {
            dead = true;
        }
        if ((dead == false))
        {
            agent.SetDestination(player.transform.position);
        }

        if (dead == true)
        {
            if (lumCollected == false)
            {
                inv.GetComponent<inventorySpace>().addItem(1, "Lumberjack Earring");
                lumCollected = true;
            }
            agent.speed = 0f;
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
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            attacking = false;
            agent.speed = 3.5f;
        }
    }

}
