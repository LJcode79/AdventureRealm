using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class inventorySpace : MonoBehaviour
{
    public TextMeshProUGUI invInfo;
    TextMeshProUGUI objTxt;
    public struct item
    {
        public int qty;
        public string name;
    }

    bool test;
    public item[] inventory = new item[50];
    int invCount = 0;
    bool inventoryShowing = false;

    string itemList = "";

    TextMeshProUGUI invPanel;

    public GameObject testInv;
    public GameObject buttons;
    public GameObject obj;
    public GameObject bandage;
    item empty;

    public float itemTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        bandage.SetActive(false);
        invInfo.text = "";
        //invPanel = GameObject.Find("HUD/InventoryHUD/invPanel/Viewport/Content").GetComponent<TextMeshProUGUI>();
        item stuff1, stuff2;
        stuff1.qty = 5;
        stuff1.name = "coolThing";

        stuff2.qty = 6;
        stuff2.name = "potato";

        //item empty;
        empty.qty = -1;
        empty.name = "";


        for (int i = 0; i < 50; i++)
        {
            inventory[i] = empty;
        }

        //inventory[0] = stuff1;
        //inventory[1] = stuff2;

        //invCount = 2;

        //invPanel.text = "--------INVENTORY--------\nSpace: " + invCount + "/50 \n------";
        //Debug.Log(stuff1.qty + " " + stuff1.name);
        //Debug.Log(inventory[0].qty + " " + inventory[0].name);

        //item test;
        //test.qty = 50;
        //test.name = "LJ";
        //addItem(50, "LJ");
        //removeItem(5, "coolThing");

    }

    // Update is called once per frame
    void Update()
    {
        itemTime -= Time.deltaTime;
        /*
        for(int i = 0; i < 10; i++)
        {
            if(inventory[i].name == "potato")
            {
                test = true;
            }
        }
        Debug.Log(test);
       */

        //Debug.Log(test);

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //testInv.SetActive(true);
            toggleInventory();
        }

        if (itemTime <= 0.0f)
        {
            invInfo.text = "";
        }
    }

    void toggleInventory()
    {
        //Debug.Log(inventoryShowing);
        if (inventoryShowing == false)
        {
            bandage.SetActive(true);
            buttons.SetActive(true);
            testInv.SetActive(true);
            obj.SetActive(true);
            inventoryShowing = true;
            invPanel = GameObject.Find("HUD/InventoryHUD/invPanel/Viewport/Content").GetComponent<TextMeshProUGUI>();
            for (int i = 0; i < 50; i++)
            {
                if (inventory[i].qty != -1)
                {
                    //Debug.Log("index = " + i);
                    itemList += inventory[i].qty + "    " + inventory[i].name + "\n";
                }
            }
            invPanel.text = "\n\n--------INVENTORY--------\n\n\nSpace Used: " + invCount + "/50 \n------------------------------\n" + itemList;
        }
        else
        {
            invPanel.text = "";
            itemList = "";
            bandage.SetActive(false);
            testInv.SetActive(false);
            buttons.SetActive(false);
            obj.SetActive(false);
            inventoryShowing = false;
        }

        

        /*
        if (inventoryShowing == false)
        {
            GameObject.Find("HUD/InventoryHUD").SetActive(true);
            inventoryShowing = true;
            Debug.Log("TESTESTEST");
        }
        else
        {
            GameObject.Find("HUD/InventoryHUD").SetActive(false);
            inventoryShowing = false;
        }
        */
    }

    public void addItem(int num, string wrd)
    {
        //Debug.Log("add works" + num + wrd);
        item newItem;
        newItem.qty = num;
        newItem.name = wrd;

        invInfo.text = newItem.qty + " " + newItem.name + " added ";
        itemTime = 5.0f;

        int i = 0;
        while ((inventory[i].qty != -1) && (i < 50) && (inventory[i].name != wrd))
        {
            //Debug.Log("i = " + i);
            i++;
        }
        if(inventory[i].name == wrd)
        {
            inventory[i].qty += num;
        }
        else if (inventory[i].qty == -1 && (inventory[i].name != wrd))
        {
            inventory[i] = newItem;
            invCount++;
        }
        i = 0;
    }

    public void removeItem(int num, string wrd)
    {
        invInfo.text = num + " " + wrd + " removed ";
        itemTime = 5.0f;
        for (int i = 0; i < 50; i++)
        {
            //Debug.Log("Remove " + i);
            if (inventory[i].name == wrd)
            {
                if (inventory[i].qty <= num)
                {
                    inventory[i] = empty;
                    invCount -= 1;
                }
                else
                {
                    inventory[i].qty -= num;
                }
            }
        }
    }

    public bool findItem(int num, string wrd)
    {
        for (int i = 0; i < 50; i++)
        {
           // Debug.Log(i);
           // Debug.Log(num + " " + wrd);
            //Debug.Log(i + ": " + inventory[i].qty + " " + inventory[i].name == wrd);
            if ((inventory[i].qty >= num) && (inventory[i].name == wrd))
            {
                return true;
            }
        }
        //Debug.Log("MISSED");
        return false;
    }
}
