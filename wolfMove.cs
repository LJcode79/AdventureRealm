using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfMove : MonoBehaviour
{
    public Animator anim;
    public GameObject player;
    //public GameObject wolf;
    public UnityEngine.AI.NavMeshAgent agent;
    bool bite = false;
    bool dead = false;
    public Collider wolfCol;
    public Collider biteCol;
    public GameObject inv;
    bool hideCollected = false;
    enemyHealth health;

    playerHealth playerhealth;
    int currentPlayerHealth;
    public float biteTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = player.GetComponent<playerHealth>();
        health = transform.gameObject.GetComponent<enemyHealth>();
        //currentPlayerHealth = 
        //anim = (Transform.GetChild(0)).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        biteTime -= Time.deltaTime;

        if (health.currentHealth <= 0)
        {
            dead = true;
        }

        if ((bite == true) && (dead == false))
        {
            if (biteTime <= 0.0f)
            {
                playerhealth.TakeDamage(20);
                biteTime = 2.0f;
            }
            agent.speed = 0.0f;
        }
        else if(dead == true)
        {
            agent.speed = 0.0f;
            wolfCol.enabled = false;
            biteCol.enabled = false;
            if (hideCollected == false)
            {
                inv.GetComponent<inventorySpace>().addItem(1, "Wolf Hide");
                hideCollected = true;
            }
            Destroy(gameObject, 10f);
        }
        else
        {
            agent.speed = 3.5f;
            agent.SetDestination(player.transform.position);
        }
        //agent.SetDestination(transform.position);
        anim.SetBool("bite", bite);
        anim.SetBool("dead", dead);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            biteTime = 2.0f;
            Debug.Log("bite!");
            bite = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            bite = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("WORKS123456");
        if (other.collider.tag == "arrow")
        {
            //Debug.Log("works12345");
            //wolfCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(1, "Wolf Hide");
            //dead = true;
            health.TakeDamage(20);
        }
        else if (other.collider.tag == "Weapon")
        {
            //Debug.Log("works12345");
            //wolfCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(1, "Wolf Hide");
            //dead = true;
            health.TakeDamage(20);
        }
    }
}
