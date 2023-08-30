using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowAnimSc : MonoBehaviour
{

    public Animator anim;
    bool dead = false;
    public Collider cowCol;
    //public inventorySpace inv;
    public GameObject inv;
    enemyHealth health;
    bool meatCollected = false;
    //int collected = 0;
    // Start is called before the first frame update
    // void Start()
    //{
    //}
    void Start()
    {
        health = transform.gameObject.GetComponent<enemyHealth>();
        //inv = GameObject.Find("Inventory").GetComponent<inventorySpace>();
        //inv = GameObject.Find("Inventory");
        //cowCol = GetComponent<Collider>();
    }
    // Update is called once per frame
    void Update()
    {
        if (health.currentHealth <= 0)
        {
            dead = true;
        }
        if (dead == true)
        {
            Destroy(gameObject, 10f);
            cowCol.enabled = false;
            if (meatCollected == false)
            {
                inv.GetComponent<inventorySpace>().addItem(5, "Meat");
                meatCollected = true;
            }
        }
        anim.SetBool("shot", dead);
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("WORKS123456");
        if (other.collider.tag == "arrow")
        {
            //Debug.Log("works12345");
            //cowCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(5, "Meat");
            //dead = true;
            health.TakeDamage(20);
        }
        else if (other.collider.tag == "Weapon")
        {
            //Debug.Log("works12345");
            //cowCol.enabled = false;
            //inv.GetComponent<inventorySpace>().addItem(5, "Meat");
            //dead = true;
            health.TakeDamage(20);
        }
    }
}
