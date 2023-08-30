using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changePic : MonoBehaviour
{
    public Image[] space = new Image[9];
    public Sprite[] newSprite = new Sprite[20];
    //public Sprite sprite1, sprite2, sprite3, sprite4, sprite5, sprite6, sprite7, sprite8, sprite9, sprite10, sprite11,
        //sprite12, sprite13, sprite14, sprite15, sprite16, sprite17, sprite18, sprite19, sprite20;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Works1");
        space[0] = GameObject.Find("hotSpace1").GetComponent<Image>();
        space[1] = GameObject.Find("hotSpace2").GetComponent<Image>();
        space[2] = GameObject.Find("hotSpace3").GetComponent<Image>();
        space[3] = GameObject.Find("hotSpace4").GetComponent<Image>();
        space[4] = GameObject.Find("hotSpace5").GetComponent<Image>();
        space[5] = GameObject.Find("hotSpace6").GetComponent<Image>();
        space[6] = GameObject.Find("hotSpace7").GetComponent<Image>();
        space[7] = GameObject.Find("hotSpace8").GetComponent<Image>();
        space[8] = GameObject.Find("hotSpace9").GetComponent<Image>();
        //sprite1 = Resources.Load<Sprite>("emptySprite");

        /**
        sprite1 = newSprite[0];
        sprite2 = newSprite[1];
        sprite3 = newSprite[2];
        sprite4 = newSprite[3];
        sprite5 = newSprite[4];
        sprite6 = newSprite[5];
        sprite7 = newSprite[6];
        sprite8 = newSprite[7];
        sprite9 = newSprite[8];
        sprite10 = newSprite[9];
        sprite11 = newSprite[10];
        sprite12 = newSprite[11];
        sprite13 = newSprite[12];
        sprite14 = newSprite[13];
        sprite15 = newSprite[14];
        sprite16 = newSprite[15];
        sprite17 = newSprite[16];
        sprite18 = newSprite[17];
        sprite19 = newSprite[18];
        sprite20 = newSprite[19];
    **/
        //space[2].sprite = sprite1;
        //Debug.Log("Works");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("TESTTEST");
        //space[3].sprite = sprite1;
    }

    public void ChangeSprite(int current, int change)
    {
        //space[current].sprite = sprite1;
        space[current].sprite = newSprite[change];
    }

    public void SwapSprite(int current, int change)
    {
        //space[current].sprite = sprite1;
        Sprite tempSprite;
        tempSprite = space[current].sprite;
        space[current].sprite = space[change].sprite;
        space[change].sprite = tempSprite;
    }
}
