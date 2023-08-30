using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class girlMove : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject player;
    float rotationSpeed = 3.0f;
    bool walking = true;
    public Animator anim;

    int activePoint = 0;
    public List<GameObject> girlPoint = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(girlPoint[0].transform.position);
        agent.angularSpeed = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("POINT " + activePoint);
        //Debug.Log("Active point " + activePoint);
        anim.SetBool("walking", walking);
        if (walking == false)
        {
            var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime).eulerAngles;
            newRotation.x = 0;
            newRotation.z = 0;
            transform.rotation = Quaternion.Euler(newRotation);
        }
        //agent.speed = 0.01f;
        //agent.SetDestination(player.transform.position);
        //transform.LookAt(player.transform.position);

        // var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime).eulerAngles;
        //newRotation.x = 0;
        //newRotation.z = 0;
        //transform.rotation = Quaternion.Euler(newRotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("POINT " + activePoint);
        if (other.GetComponent<Collider>().name == "player")
        {
            //agent.isStopped = true;
            agent.SetDestination(gameObject.transform.position);
            agent.speed = 0.0f;
            walking = false;

           //Debug.Log("WORKS12354");
        }
        else if (other.GetComponent<Collider>().tag == "point")
        {
            //Debug.Log("HIT POINT");
            if (activePoint == 0)
            {
                activePoint = 1;
                agent.SetDestination(girlPoint[1].transform.position);
            }
            else
            {
                activePoint = 0;
                agent.SetDestination(girlPoint[0].transform.position);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            //agent.isStopped = false;
            agent.SetDestination(girlPoint[activePoint].transform.position);
            walking = true;
            agent.speed = 2.5f;
            //walk around
        }
    }

    /**
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "point")
        {
            if (activePoint == 0)
            {
                activePoint = 1;
                agent.SetDestination(girlPoint[1].transform.position);
            }
            else
            {
                activePoint = 0;
                agent.SetDestination(girlPoint[0].transform.position);
            }
        }
    }
    **/
}
