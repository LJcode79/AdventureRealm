using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class playerHealth : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent killed;
    public int maxHealth = 100;
    public int currentHealth;
    int bandages = 4;
    TextMeshProUGUI numBandage;


    //public GameObject healthbarOb;
    //healthBar healthbar = healthbarOb.
    public healthBar healthbar;
    // Start is called before the first frame update
    void Awake()
    {
        numBandage = GameObject.Find("HUD/bandage/num").GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        //numBandage = GameObject.Find("HUD/bandage/num").GetComponent<TextMeshProUGUI>();
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            killed.Invoke();
        }
        numBandage.text = bandages.ToString();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("SPACE");
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }

    public void Heal(int hp)
    {
        currentHealth += hp;
        healthbar.SetHealth(currentHealth);
        bandages -= 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "eSword")
        {
            TakeDamage(10);
        }
        if (other.GetComponent<Collider>().tag == "eAxe")
        {
            TakeDamage(20);
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("TRUE");
        if (other.collider.tag == "archerArrow")
        {
            TakeDamage(30);
        }
    }
}

