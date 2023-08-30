using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inRange : MonoBehaviour
{
    public GameObject archerAim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            archerAim.GetComponent<archerArrowScript>().inRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Collider>().name == "player")
        {
            archerAim.GetComponent<archerArrowScript>().inRange = false;
            archerAim.GetComponent<archerArrowScript>().wait = 4.7f;
        }
    }
}
