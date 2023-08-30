using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropItem : MonoBehaviour
{
    //public Transform spawnPoint;
    string child;
    GameObject childOb;
    int index;
    GameObject emptyInd;
    GameObject holder;
    GameObject unequipped;
    GameObject spaces;
    GameObject highlight;
    public int swap1 = -2;
    public int swap2 = -2;
    //string firstChild = holder.transform.GetChild(1).transform.name;
    // Start is called before the first frame update
    void Start()
    {
        //public GameObject holder = GameObject.Find("WeaponHolder");
        //index = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().selectedWeapon;
        holder = GameObject.Find("WeaponHolder");
        unequipped = GameObject.Find("unEquipped");
        spaces = GameObject.Find("spaces");
        highlight = GameObject.Find("highlights");
        //firstChild = holder.transform.GetChild(1).transform.name;

        //child = holder.transform.GetChild(index).transform.name;

        //Debug.Log("FIRST" + child);
    }

    // Update is called once per frame
    void Update()
    {
        index = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().selectedWeapon;
        emptyInd = GameObject.Find("empty" + (index+1));
        child = holder.transform.GetChild(index).transform.name;
        childOb = holder.transform.GetChild(index).gameObject;
        // Debug.Log("FIRST" + child);

        //Debug.Log("INDEX" + index);
        //Debug.Log("INDEX" + GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().selectedWeapon);

        if (Input.GetKeyDown(KeyCode.G))
        {
            ItemDrop();
        }
    }

    public void ItemDrop()
    {
        //Debug.Log("TESTTT" + firstChild);
        //var item = Instantiate(Resources.Load("bowWithString", typeof(GameObject)), transform.position, transform.rotation);
        //var item = Instantiate(Resources.Load(holder.transform.GetChild(1).transform.name), transform.position, transform.rotation);
        if (!(childOb.name).Contains("empty"))
        {
            var item = Instantiate(Resources.Load(child, typeof(GameObject)), transform.position, transform.rotation);
        }
        //Debug.Log("spawned item");

        childOb.transform.parent = unequipped.transform;

        emptyInd.transform.parent = holder.transform;
        //holder.transform.GetChild(transform.childCount - 1).SetSiblingIndex(index);
        holder.transform.GetChild(holder.transform.childCount - 1).SetSiblingIndex(index);

        spaces.GetComponent<changePic>().ChangeSprite(index, 1);
    }

    public void ItemSwap(int slot)
    {
        //Debug.Log("1 = " + swap1);
        //Debug.Log("2 = " + swap2);

        if (swap1 == -2)
        {
            swap1 = slot;
        }
        else if(swap2 == -2 && swap1 != -2)
        {
            Debug.Log("SECOND CONDITION");
            swap2 = slot;

            //Debug.Log("1 = " + swap1);
            //Debug.Log("2 = " + swap2);
            if ((!(holder.transform.GetChild(swap1).name).Contains("empty")) && ((!(holder.transform.GetChild(swap2).name).Contains("empty"))))
            {
                int modSlot = swap2 - 1;
                if (modSlot == -1)
                {
                    modSlot = 0;
                }

                int modSlot2 = swap2 + 1;
                if (modSlot2 == 9)
                {
                    modSlot2 = 8;
                }

                //Debug.Log("1 = " + swap1);
                //Debug.Log("modslot1 = " + modSlot);
                //Debug.Log("modslot2 = " + modSlot2);

                //if (swap1 < modSlot)
                if (swap1 - 1 < modSlot)
                {
                    Debug.Log("ACTIVATED");
                    holder.transform.GetChild(swap1).SetSiblingIndex(swap2);
                    holder.transform.GetChild(modSlot).SetSiblingIndex(swap1);
                }
                else
                {
                    //Debug.Log("ACTIVATED");
                    holder.transform.GetChild(swap1).SetSiblingIndex(swap2);
                    holder.transform.GetChild(modSlot2).SetSiblingIndex(swap1);
                }
                spaces.GetComponent<changePic>().SwapSprite(swap1, swap2);

                if (index == swap2)
                {
                    highlight.GetComponent<hotBar>().selectedHighlight = swap1;
                    holder.GetComponent<WeaponSwitching>().selectedWeapon = swap1;
                }
                else
                {
                    highlight.GetComponent<hotBar>().selectedHighlight = swap2;
                    holder.GetComponent<WeaponSwitching>().selectedWeapon = swap2;
                }
                highlight.GetComponent<hotBar>().SelectHighlight();
                holder.GetComponent<WeaponSwitching>().SelectWeapon();

                //holder.GetComponent<WeaponSwitching>().selectedWeapon = swap2;
                //holder.transform.GetChild(swap2).SetSiblingIndex(swap1);

                //holder.transform.GetChild(swap1).SetSiblingIndex(7);
                //holder.transform.GetChild(swap2).SetSiblingIndex(8);
                swap1 = -2;
                swap2 = -2;
            }
            else
            {
                swap1 = -2;
                swap2 = -2;
            }
        }
    }
}
