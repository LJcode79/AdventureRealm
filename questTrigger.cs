using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class questTrigger : MonoBehaviour
{
    TextMeshProUGUI farmerTxt;

    void Awake()
    {
        farmerTxt = GameObject.Find("HUD/quest").GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    //void Update()
    //{
        
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            farmerTxt.text = "Hello I am a farmer";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            farmerTxt.text = "";
        }
    }
}
