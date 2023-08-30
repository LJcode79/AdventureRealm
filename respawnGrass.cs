using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawnGrass : MonoBehaviour
{
    public float spawnTime = 10.0f;
    public bool exist = true;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if ((spawnTime <= 0.0f) && (exist == false))
        {
            Debug.Log("SPAWNED TEST!");
            transform.GetComponent<MeshRenderer>().enabled = true;
            transform.GetComponent<Collider>().enabled = true;
            exist = true;
        }
        /*
        if (boolExist = false)
        {
            spawnTime = 10.0f;
            if (spawnTime <= 0.0f)
            {
                GetComponent<MeshRenderer>().enabled = true;
                GetComponent<Collider>().enabled = true;
            }
        }
        */
    }
    public void respawn()
    {
        Debug.Log("Respawn called");
        spawnTime = 10.0f;
        exist = false;
    }
}
