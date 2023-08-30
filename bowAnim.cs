using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowAnim : MonoBehaviour
{
    Animator anim;
    bool isEmpty = false;
    bool isPulled = false;
    bool reload = false;
    bool stayPulled = false;

    public float waitAnim = 1.0f;
    public float desiredTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        waitAnim -= Time.deltaTime;
        //Debug.Log("wait = "+ waitAnim);
        if (Input.GetButtonDown("Fire1"))
        {
            isPulled = true;
            stayPulled = true;
            isEmpty = false;
            Debug.Log("pulled" + isPulled);
            waitAnim = desiredTime;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            //Debug.Log("WORKS");
            if (isEmpty == false && waitAnim <= 0.0f)
            {
                GetComponent<arrowScript>().Shoot();
                waitAnim = desiredTime;
            }
            Debug.Log("Not pulled");
            isPulled = false;
            isEmpty = true;
            reload = false;
        }
        if (isEmpty == true && reload == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
                {
                reload = true;
                isEmpty = false;
                stayPulled = false;
                }
        }
        anim.SetBool("isPulled", isPulled);
        anim.SetBool("isEmpty", isEmpty);
        anim.SetBool("reload", reload);
        anim.SetBool("stayPulled", stayPulled);
    }
}
