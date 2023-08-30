using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerArrowScript : MonoBehaviour
{
    public float damage = 10f;
    //public Transform spawnPoint;
    public float range = 100f;
    public float arrowSpeed = 50f;
    public GameObject arrowPrefab;
    public GameObject player;
    float rotationSpeed = 3.0f;
    public float wait = 4.7f;

    public bool inRange = false;
    public Animator anim;
    public GameObject archer;
    archerAim aim;
    //public Animator anim;
    //bool shoot = false;
    // Start is called before the first frame update
    void Start()
    {
        aim = archer.GetComponent<archerAim>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("inRange", inRange);
        anim.SetBool("dead", aim.dead);
        if ((inRange == true) && (aim.dead == false))
        {
            wait -= Time.deltaTime;
            var newRotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), rotationSpeed * Time.deltaTime).eulerAngles;
            transform.rotation = Quaternion.Euler(newRotation);
            if (wait <= 0f)
            {
                var arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
                arrow.GetComponent<Rigidbody>().velocity = transform.forward * arrowSpeed;
                Destroy(arrow.gameObject, 10f);
                wait = 4.7f;
            }
        }
    }
}
