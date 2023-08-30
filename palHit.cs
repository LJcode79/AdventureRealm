using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class palHit : MonoBehaviour
{
    public Animator anim;
    public GameObject inv;
    public GameObject pal;
    //public Collider palColl;
    public Collider palAttColl;
    public UnityEngine.AI.NavMeshAgent agent;
    public enemyHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = transform.gameObject.GetComponent<enemyHealth>();
        health.currentHealth = transform.gameObject.GetComponent<enemyHealth>().currentHealth;
    }

    // Update is called once per frame
    void Update()
    {
        health.currentHealth = pal.GetComponent<enemyHealth>().currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            //Debug.Log("obj" + other.gameObject.tag);
            //pal.GetComponent<palMove>().dead = true;
            pal.GetComponent<enemyHealth>().TakeDamage(20);
            //pal.GetComponent<palMove>().chasing = false;
            //agent.speed = 0.0f;
            //inv.GetComponent<inventorySpace>().addItem(1, "Knight Chain");
            //palColl.enabled = false;
        }
        else if(other.gameObject.tag == "arrow")
        {
            pal.GetComponent<enemyHealth>().TakeDamage(100);
        }
    }
}
