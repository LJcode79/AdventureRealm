using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hotBar : MonoBehaviour
{
    public int selectedHighlight = 0;
    //static public List highlights;
    //public List<Image> highlights;
    //public List<GameObject> highlights;
    public GameObject[] highlights = new GameObject[9];

    // Start is called before the first frame update
    void Start()
    {
        //highlights = new List<Image>();
        //highlights = new List<GameObject>();
        //highlights = new GameObject[9];
        SelectHighlight();
    }

    // Update is called once per frame
    void Update()
    {

        int previousSelectedHighlight = selectedHighlight;

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedHighlight >= 8)
                selectedHighlight = 0;
            else
                selectedHighlight++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedHighlight <= 0)
                selectedHighlight = 8;
            else
                selectedHighlight--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedHighlight = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedHighlight = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedHighlight = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedHighlight = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedHighlight = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedHighlight = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedHighlight = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            selectedHighlight = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            selectedHighlight = 8;
        }

        if (previousSelectedHighlight != selectedHighlight)
        {
            SelectHighlight();
        }
    }
    public void SelectHighlight()
    {
       // Debug.Log("works");
        int i = 0;
        //Debug.Log("i = " + i);
        //foreach (GameObject img in GameObject)
        foreach (Transform child in transform)
        {
            if (i == selectedHighlight)
                //rect.gameObject.SetActive(true);
                highlights[i].SetActive(true);
            //highlights[i].enabled = true;
            else
                //rect.gameObject.SetActive(false);
                highlights[i].SetActive(false);
            //highlights[i].enabled = false;
            i++;
            //Debug.Log("i = " + i);
        }
    }
    /**
    void SelectHighlight()
    {
        Debug.Log("works");
        int i = 0;
        Debug.Log("i = " + i);
        //foreach (RectTransform rect in RectTransform)
        foreach (Transform child in transform)
        {
            if (i == selectedHighlight)
                //rect.gameObject.SetActive(true);
                highlights[i].SetActive(true);
                //highlights[i].enabled = true;
            else
                //rect.gameObject.SetActive(false);
                highlights[i].SetActive(false);
                //highlights[i].enabled = false;
            i++;
            Debug.Log("i = " + i);
        }
    }
    **/
}
