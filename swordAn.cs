using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAn : MonoBehaviour
{
    Animator anim;
    bool swing = false;
    public float waitAnim = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gameObject.tag = "Untagged";
        //gameObject.tag = "arrow";
    }

    // Update is called once per frame
    void Update()
    {
        waitAnim -= Time.deltaTime;
        if (Input.GetButtonDown("Fire1") && (waitAnim <= 0.0f))
        {
            swing = true;
            gameObject.tag = "Weapon";
            Debug.Log("swing!");
        }
        else if ((swing == true) && (waitAnim != 1.0f))
        {
            swing = false;
            //gameObject.tag = "Untagged";
            waitAnim = 1.0f;
        }
        else if (waitAnim <= .5f)
        {
            gameObject.tag = "Untagged";
        }
        anim.SetBool("swing", swing);
    }
}
