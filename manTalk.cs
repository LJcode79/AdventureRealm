using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manTalk : MonoBehaviour
{
    public GameObject player;
    float rotationSpeed = 3.0f;
    public bool talking = false;
    //public bool scared = false;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("talking", talking);
        //anim.SetBool("scared", scared);
        if (talking == true)
        {
            var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime).eulerAngles;
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Euler(newRotation);
        }
    }
    //private void OnTriggerExit(Collider other)
    //{
        //if (other.name == "player")
        //if (other.GetComponent<Collider>().name == "player")
        //{ 
            //talking = false;
            //Debug.Log("SET FALSE");
        //}
    //}
}
