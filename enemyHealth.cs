using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
   // public int maxHealth = 100;
    public int currentHealth = 100;
    //public GameObject healthbarOb;
    //healthBar healthbar = healthbarOb.
    //public healthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        //healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("SPACE");
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        //healthbar.SetHealth(currentHealth);
    }
}
