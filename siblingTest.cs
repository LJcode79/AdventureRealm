using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siblingTest : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject unEquipped;
    void Start()
    {
        unEquipped = GameObject.Find("unEquipped");
        //GameObject unEquipped = GameObject.Find("unEquipped");
        //transform.GetChild(0).transform.parent = unEquipped.transform;
        //unEquipped.transform.GetChild(0).transform.parent = transform;
        //transform.GetChild(transform.childCount - 1).SetSiblingIndex(0);

        //-----------------------above is good

        //unEquipped.GetChild
        //transform.GetChild(0).transform.parent = null;
        //transform.GetChild(0).transform.SetParent(unEquipped.transform);
        //transform.SetSiblingIndex(3);

        //-------------bottom good
        //foreach (Transform weapon in unEquipped.transform)
        //{
        //weapon.gameObject.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform weapon in unEquipped.transform)
        {
            if (weapon.name != "empty1" && weapon.name != "empty2" && weapon.name != "empty3" && weapon.name != "empty4" && weapon.name != "empty5" && weapon.name != "empty6"
                && weapon.name != "empty7" && weapon.name != "empty8" && weapon.name != "empty9")
            {
                weapon.gameObject.SetActive(false);
            }
        }

    }
}
