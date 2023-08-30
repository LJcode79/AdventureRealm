using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowScript : MonoBehaviour
{
    public float damage = 10f;
    public Transform spawnPoint;
    public float range = 100f;
    public float arrowSpeed = 50f;
    public GameObject arrowPrefab;
    // Start is called before the first frame update
    /**
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    **/

    public void Shoot()
    {
        //var arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        //Vector3 xyz = new Vector3(0, 0, 0);
        //Quaternion newRotation = Quaternion.Euler(xyz);
        //var arrow = Instantiate(arrowPrefab, spawnPoint.position, newRotation);
        var arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
        arrow.GetComponent<Rigidbody>().velocity = spawnPoint.forward * arrowSpeed;
        Destroy(arrow.gameObject, 1f);
        //GetComponent<AudioSource>().Play();
        Debug.Log("Shoot called");
    }
}
