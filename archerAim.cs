using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerAim : MonoBehaviour
{
    public GameObject player;
    float rotationSpeed = 3.0f;
    //public Animator anim;
    public bool dead = false;
    public GameObject inv;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetBool("dead", dead);
        if (dead == false)
        {
            var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime).eulerAngles;
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("WORKS123456");
        if (other.collider.tag == "arrow")
        {
            //Debug.Log("works12345");
            dead = true;
            inv.GetComponent<inventorySpace>().addItem(1, "Archer Quiver");
        }

    }
}
