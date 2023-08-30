using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bHit : MonoBehaviour
{
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
        //health.currentHealth = transform.gameObject.GetComponent<enemyHealth>().currentHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            pal.GetComponent<enemyHealth>().TakeDamage(20);
            //health.TakeDamage(20);
        }
        else if(other.gameObject.tag == "arrow")
        {
            pal.GetComponent<enemyHealth>().TakeDamage(100);
            //health.TakeDamage(100);
        }
    }
}
