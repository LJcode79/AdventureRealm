using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archArrStick : MonoBehaviour
{
    public void OnCollisionEnter(Collision col)
    {
        if ((col.transform.tag == "target") || (col.transform.tag == "Player"))
        {
            transform.parent = col.transform.parent;
            //GetComponent<Rigidbody>().isKinematic = true;
            //transform.SetParent(col.transform, true);
            //transform.localScale = new Vector3(.7f, .2f, .2f);
        }
    }
}
