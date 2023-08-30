using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goatMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Animator anim;
    public Collider goatCol;
    public GameObject inv;
    bool dead = false;
    //enemyHealth health;
    public enemyHealth health;
    bool skinCollected = false;

    int activePoint = 0;
    public List<GameObject> goatPoint = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(goatPoint[0].transform.position);
        agent.angularSpeed = 90.0f;
        //health = transform.gameObject.GetComponent<enemyHealth>();
        //health = enemyHealthOb.GetComponent<enemyHealth>();
    }

    void Update()
    {
        if (health.currentHealth <= 0)
        {
            dead = true;
        }
        if (dead == true)
        {
            if (skinCollected == false)
            {
                inv.GetComponent<inventorySpace>().addItem(1, "Goat Skin");
                skinCollected = true;
            }
            agent.speed = 0.0f;
            goatCol.enabled = false;
            Destroy(gameObject, 10f);
        }
        anim.SetBool("dead", dead);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "point")
        {
            //Debug.Log("HIT POINT");
            if (activePoint == 0)
            {
                activePoint = 1;
                agent.SetDestination(goatPoint[1].transform.position);
            }
            else
            {
                activePoint = 0;
                agent.SetDestination(goatPoint[0].transform.position);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("WORKS123456");
        if (other.collider.tag == "arrow")
        {
            //Debug.Log("works12345");
            //goatCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(1, "Goat Skin");
            //dead = true;
            health.TakeDamage(100);
        }
        else if (other.collider.tag == "Weapon")
        {
            //Debug.Log("works12345");
            //goatCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(1, "Goat Skin");
            //dead = true;
            health.TakeDamage(20);
        }
    }
}
