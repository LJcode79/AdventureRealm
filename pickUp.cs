using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class pickUp : MonoBehaviour
{
    TextMeshProUGUI qTxt;
    TextMeshProUGUI objTxt;
    TextMeshProUGUI x;
    public GameObject inventory;
    public GameObject obj;
    public GameObject questBack;
    public float range = 30f;
    public Camera fpsCam;

    string child;
    GameObject childOb;
    int index;
    GameObject holder;
    GameObject unequipped;
    GameObject spaces;
    GameObject emptyInd;
    GameObject hoe;
    GameObject bow;
    GameObject sword;
    public int questNumber = 0;
    public int questProgress = 0;
    public int dialogue = 0;
    public float qTime = 5.0f;

    public GameObject trader;
    public GameObject farmer;
    public GameObject wanderer;
    public string speaker;
    public string lastSpeaker;

    bool harvested = false;
    bool hideColl = false;
    bool deliverHide = false;
    bool wineCollected = false;

    public GameObject wolf1;
    public GameObject wolf2;
    public GameObject wolf3;

    public GameObject deadPhil;

    public healthBar ehealthbar;
    public GameObject ehealthOb;
    TextMeshProUGUI enemyName;
    TextMeshProUGUI npcName;

    public GameObject farmCamp;
    public GameObject lumberjacks;
    // Start is called before the first frame update
    void Awake()
    {
        x = GameObject.Find("HUD/X").GetComponent<TextMeshProUGUI>();
        npcName = GameObject.Find("HUD/NPCname").GetComponent<TextMeshProUGUI>();
        enemyName = GameObject.Find("HUD/EnemyName").GetComponent<TextMeshProUGUI>();
        objTxt = obj.GetComponent<TextMeshProUGUI>();
        qTxt = GameObject.Find("HUD/quest").GetComponent<TextMeshProUGUI>();
        holder = GameObject.Find("WeaponHolder");
        unequipped = GameObject.Find("unEquipped");
        spaces = GameObject.Find("spaces");
        bow = GameObject.Find("bowWithString");
        sword = GameObject.Find("colorSword");
        hoe = GameObject.Find("Hoe");

        Debug.Log(bow.name);
        //Debug.Log(sword.name);
    }

    void Start()
    {
        x.text = "";
        npcName.text = "";
        objTxt.text = "Current Objective: talk to the farmer";
        qTxt.text = "";
        qTime = 0.0f;
        questBack.SetActive(false);
    }


    //if (Input.GetKeyDown(KeyCode.R))
    // Update is called once per frame
    void Update()
    {
        //wanderer.GetComponent<manTalk>().scared = true;
        if (speaker != "")
        {
            lastSpeaker = speaker;
        }
        //Debug.Log("SPEAKER " + speaker);
        //Debug.Log("CHAIN" + (inventory.GetComponent<inventorySpace>().findItem(2, "Knight Chain")));
        //Debug.Log("QUIVER" + (inventory.GetComponent<inventorySpace>().findItem(2, "Archer Quiver")));
        if (Input.GetKeyDown(KeyCode.Q))
        {
            qTime = 20.0f;
            dialogue += 1;
            Debug.Log("q");
            Debug.Log(dialogue);
        }

        if (speaker == "farmer")
        {
            if ((dialogue == 0) && (questNumber == 0) && (questProgress == 0))
            {
                //Debug.Log(inventory.GetComponent<inventorySpace>().findItem(2, "Wheat"));
                qTxt.text = "Hello lad, fetch me 10 wheat with the hoe on the table in the back, we must get ready for a feast the king requested. (press Q to continue)";
                //questProgress++;
                //qTime = 20.0f;
            }
            else if ((dialogue == 1) && (questNumber == 0) && (questProgress == 0))
            {
                Debug.Log("working Q");
                qTxt.text = "After you are done fetching wheat, slay a cow and give me 5 meat so I can cook it for you.";
                objTxt.text = "Current Objective: collect 10 wheat and 5 meat";
                questProgress += 1;
                speaker = "";
                //if (qTime <= 0.0f)
                //{
                //    qTxt.text = "";
                //}
            }
            else if ((questNumber == 0) && (questProgress == 1))
            {
                if ((inventory.GetComponent<inventorySpace>().findItem(10, "Wheat") == false) && (inventory.GetComponent<inventorySpace>().findItem(5, "Meat") == true))
                {
                    qTxt.text = "You're missing 10 wheat";
                    objTxt.text = "Current Objective: collect 10 wheat";
                    //questProgress += 1;d
                }
                else if ((inventory.GetComponent<inventorySpace>().findItem(5, "Meat") == false) && (inventory.GetComponent<inventorySpace>().findItem(10, "Wheat") == true))
                {
                    objTxt.text = "Current Objective: collect 5 meat";
                    qTxt.text = "You're missing 5 meat";
                }
                else if ((inventory.GetComponent<inventorySpace>().findItem(5, "Meat") == false) && (inventory.GetComponent<inventorySpace>().findItem(10, "Wheat") == false))
                {
                    qTxt.text = "You're missing 5 meat and 10 wheat";
                }
                else
                {
                    qTxt.text = "Good job, now give me the meat and wheat";
                    objTxt.text = "Current Objective: give the farmer the wheat and meat";
                    //inventory.GetComponent<inventorySpace>().removeItem(5, "Meat");
                    //inventory.GetComponent<inventorySpace>().removeItem(10, "Wheat");
                    //harvested = true;
                    speaker = "";
                    questProgress += 1;
                    //questProgress += 1;
                }
                if (qTime <= 0.0f)
                {
                    qTxt.text = "";
                }
            }
            if ((inventory.GetComponent<inventorySpace>().findItem(5, "Meat") == true) && (inventory.GetComponent<inventorySpace>().findItem(10, "Wheat") == true) && (harvested == false) && (questProgress == 2) && (speaker == "farmer"))
            {
                inventory.GetComponent<inventorySpace>().removeItem(5, "Meat");
                inventory.GetComponent<inventorySpace>().removeItem(10, "Wheat");
                harvested = true;
                questProgress += 1;
            }
            if ((questProgress == 3) && (harvested == true))
            {
                qTxt.text = "Give me a second, I'll start cooking the bread and beef";
                objTxt.text = "Current Objective: wait for the farmer to cook food";
                if (qTime <= 10)
                {
                    questProgress += 1;
                }
            }
            if ((questNumber == 0) && (questProgress == 4))
            {
                //qTime = 10.0f;
                qTxt.text = "Watch out there's wolves coming!";
                objTxt.text = "Current Objective: kill the wolves";
                wolf1.SetActive(true);
                wolf2.SetActive(true);
                wolf3.SetActive(true);
                if (inventory.GetComponent<inventorySpace>().findItem(3, "Wolf Hide") == true)
                {
                    //objTxt.text = "Current Objective: speak to the farmer";
                    questNumber += 1;
                    questProgress = 0;
                    dialogue = 0;
                    //speaker = "";
                    hideColl = true;
                }
                if (hideColl == false)
                {
                    speaker = "";
                }
            }
            else if ((dialogue == 0) && (questNumber == 1) && (questProgress == 0))
            {
                qTxt.text = "Thanks for saving me from those wolves, here is the bread and cooked meat (press Q to continue)";
                inventory.GetComponent<inventorySpace>().addItem(5, "Cooked Meat");
                inventory.GetComponent<inventorySpace>().addItem(5, "Bread");
                questProgress += 1;
            }
            else if ((dialogue == 1) && (questNumber == 1) && (questProgress == 1))
            {
                qTxt.text = "Can you deliver the wolf hides to Sir Biggles in town? He should also have wine and fruit in stock for the feast.";
                objTxt.text = "Current Objective: deliver wolf hide to Sir Biggles";
            }
        }

        else if (speaker == "biggles")
        {
            if ((dialogue == 0) && (questNumber == 1) && (questProgress == 1))
            {
                qTxt.text = "Hello Lad how are you doing? (press Q to continue)";
            }
            else if ((dialogue == 1) && (questNumber == 1) && (questProgress == 1))
            {
                if (deliverHide == false)
                {
                    inventory.GetComponent<inventorySpace>().removeItem(3, "Wolf Hide");
                    deliverHide = true;
                    questProgress += 1;
                    dialogue = 0;
                }
                //qTxt.text = "thank you for delivering those wolf hides to me (press Q to continue)";
            }
            else if ((dialogue == 0) && (questNumber == 1) && (questProgress == 2))
            {
                qTxt.text = "thank you for delivering those wolf hides to me (press Q to continue)";
            }
            else if ((dialogue == 1) && (questNumber == 1) && (questProgress == 2))
            {
                qTxt.text = "eh, what was that? You wanted wine? Sure, I'll give ye some, only if you do me a favor. (press Q to continue)";
            }
            else if ((dialogue == 2) && (questNumber == 1) && (questProgress == 2))
            {
                qTxt.text = "We've heard that there are bandits camped out on the hill near town. (press Q to continue)";
            }
            else if ((dialogue == 3) && (questNumber == 1) && (questProgress == 2))
            {
                qTxt.text = "Can you eliminate them for me? Then I'll give ye the wine.";
                objTxt.text = "Current Objective: eliminate bandits on the hill";
                speaker = "";
                questProgress += 1;
                dialogue = 0;
            }
            else if ((dialogue == 0) && (questNumber == 1) && (questProgress == 3))
            {
                if ((speaker == "biggles") && (inventory.GetComponent<inventorySpace>().findItem(3, "Knight Chain") == true))
                {
                    questProgress += 1;
                    dialogue = 0;
                }
                else
                {
                    qTxt.text = "Those camps aren't gonna clear themselves";
                }
            }
            else if ((dialogue == 0) && (questNumber == 1) && (questProgress == 4))
            {
                qTxt.text = "Thanks for getting rid of the bandits! Here is yer Wine. (press Q to continue)";
                inventory.GetComponent<inventorySpace>().removeItem(3, "Knight Chain");

            }
            else if ((dialogue == 1) && (questNumber == 1) && (questProgress == 4))
            {
                qTxt.text = "I don't have any berries, yer gonna have ta find someone else pal (press Q to continue)";
                if (wineCollected == false)
                {
                    inventory.GetComponent<inventorySpace>().addItem(2, "Wine");
                    wineCollected = true;
                }
            }
            else if ((dialogue == 2) && (questNumber == 1) && (questProgress == 4))
            {
                qTxt.text = "Also, word has come ta town that yer farm is being attacked!";
                farmCamp.SetActive(true);
                deadPhil.SetActive(true);
                farmer.SetActive(false);
                objTxt.text = "Current Objective: return to your farm and defend it";
                speaker = "";
                questProgress += 1;
            }
            else if ((questNumber == 1) && (questProgress == 5))
            {
                if ((speaker == "biggles") && (inventory.GetComponent<inventorySpace>().findItem(2, "Knight Chain") == true) && (inventory.GetComponent<inventorySpace>().findItem(2, "Archer Quiver") == true))
                {
                    questProgress += 1;
                }
                else
                {
                    qTxt.text = "Ya better get goin then lad, Phil needs ye";
                }
            }
            else if ((questNumber == 1) && (questProgress == 6))
            {
                if ((inventory.GetComponent<inventorySpace>().findItem(2, "Knight Chain") == true) && inventory.GetComponent<inventorySpace>().findItem(2, "Archer Quiver") == true && (lastSpeaker == "biggles"))
                {
                    qTxt.text = "Ah sorry for yer loss mate, on a brighter note, Lisa told me that she has some berries for ya";
                    questNumber += 1;
                    dialogue = 0;
                    questProgress = 0;
                }
            }
        }
        if ((inventory.GetComponent<inventorySpace>().findItem(3, "Wolf Hide") == true) && (questNumber == 0) && (questProgress == 4))
        {
            objTxt.text = "Current Objective: return to farmer Phil";
        }

        if ((questNumber == 1) && (questProgress == 5) && (inventory.GetComponent<inventorySpace>().findItem(2, "Knight Chain") == true) && (inventory.GetComponent<inventorySpace>().findItem(2, "Archer Quiver") == true) && (lastSpeaker == "biggles"))
        {
            objTxt.text = "Current Objective: return to Sir Biggles";

        }
        if ((inventory.GetComponent<inventorySpace>().findItem(3, "Knight Chain") == true) && (questNumber == 1) && (questProgress == 3))
        {
            objTxt.text = "Current Objective: return to Sir Biggles";
        }
        else if (speaker == "woman")
        {
            if (questNumber < 2)
            {
                qTxt.text = "Hello, I am Lady Lisa";
            }
            else if ((questNumber == 2) && (questProgress == 0) && (dialogue == 0))
            {
                qTxt.text = "You needed some berries? Biggles told me about you (press Q to continue)";
            }
            else if ((questNumber == 2) && (questProgress == 0) && (dialogue == 1))
            {
                qTxt.text = "Unfortunately I left my berry bag full of berries somewhere in the forest just beyond the village, but I couldn't seem to find it. (press Q to continue)";
            }
            else if ((questNumber == 2) && (questProgress == 0) && (dialogue == 2))
            {
                qTxt.text = "If you find it, feel free to keep the berries, I have a spare bag at home.";
                objTxt.text = "Current Objective: Find Lisa's berry bag in the forest just beyond the village";
                questNumber += 1;
                dialogue = 0;
            }
        }
        else if (speaker == "wanderer")
        {
            if ((questNumber == 3) && (questProgress == 0) && (dialogue == 0))
            {
                qTxt.text = "Eh? Who are you? (press Q to continue)";
            }
            else if ((questNumber == 3) && (questProgress == 0) && (dialogue == 1))
            {
                qTxt.text = "Oh I see, just some run of the mill farmer boy... (press Q to continue)";
            }
            else if ((questNumber == 3) && (questProgress == 0) && (dialogue == 2))
            {
                qTxt.text = "Is this what you want? This berry bag I found? (press Q to continue)";
            }
            else if ((questNumber == 3) && (questProgress == 0) && (dialogue == 3))
            {
                qTxt.text = "Well go get me 2 goat skin and I'll give it to you.";
                objTxt.text = "Current Objective: Obtain 2 goatskin for the wanderer";
                speaker = "";
                questProgress += 1;
                dialogue = 0;
            }
            else if ((questNumber == 3) && (questProgress == 1))
            {
                if ((speaker == "wanderer") && (inventory.GetComponent<inventorySpace>().findItem(2, "Goat Skin") == true))
                {
                    questProgress += 1;
                    dialogue = 0;
                }
                else
                {
                    qTxt.text = "Well go get me 2 goat skin and I'll give it to you.";
                }
            }
            else if ((questNumber == 3) && (questProgress == 2) && (dialogue == 0))
            {
                lumberjacks.SetActive(true);
                qTxt.text = "After him boys!";
                objTxt.text = "Current Objective: fend off the attackers";
                questProgress += 1;
                dialogue = 0;
            }
            else if ((questNumber == 3) && (questProgress == 3))
            {
                if ((speaker == "wanderer") && (inventory.GetComponent<inventorySpace>().findItem(3, "Lumberjack Earring") == true))
                {
                    questProgress += 1;
                    dialogue = 0;
                    wanderer.GetComponent<wanTalk>().scared = true;
                }
            }
            else if ((questNumber == 3) && (questProgress == 4) && (dialogue == 0))
            {
                qTxt.text = "Okay, okay! I surrender, You win! just take this berry pouch already";
                speaker = "";
                inventory.GetComponent<inventorySpace>().addItem(1, "Berry Pouch");
                objTxt.text = "Current Objective: deliver the ingredients to the King!";
                questNumber += 1;
                questProgress = 0;
                dialogue = 0;
            }
        }
        else if (speaker == "king")
        {
            if ((questNumber == 4) && (questProgress == 0) && (dialogue == 0))
            {
                qTxt.text = "Thank you for delivering the ingredients for my feast, from now on, you shall be considered an honorary knight of the Adventure Realm for what you have gone through.";
                inventory.GetComponent<inventorySpace>().removeItem(5, "Bread");
                inventory.GetComponent<inventorySpace>().removeItem(5, "Cooked Meat");
                inventory.GetComponent<inventorySpace>().removeItem(2, "Wine");
                inventory.GetComponent<inventorySpace>().removeItem(1, "Berry Pouch");
            }
        }
        if ((inventory.GetComponent<inventorySpace>().findItem(2, "Goat Skin") == true) && (questNumber == 3) && (questProgress == 1))
        {
            objTxt.text = "Current Objective: return to the Wanderer";
        }


        qTime -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.X))
        {
            qTime = 0.1f;
            x.text = "";
        }
        if (qTime <= 0.0f)
        {
            questBack.SetActive(false);
            qTxt.text = "";
            speaker = "";
            x.text = "";
        }
        else
        {
            x.text = "Press X to close";
            questBack.SetActive(true);
        }
        //Debug.Log("TEST");
        emptyInd = GameObject.Find("empty" + (index + 1));
        index = GameObject.Find("WeaponHolder").GetComponent<WeaponSwitching>().selectedWeapon;
        child = holder.transform.GetChild(index).transform.name;
        childOb = holder.transform.GetChild(index).gameObject;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
        CheckName();
    }

    void Shoot()
    {
        //Debug.Log("SHOOT");
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //Debug.Log(hit.transform.name);
            if (hit.transform.name == "bowWithString(Clone)")
            {
                if ((childOb.name).Contains("empty"))
                {
                    childOb.transform.parent = unequipped.transform;
                    bow.transform.parent = holder.transform;
                    bow.transform.SetSiblingIndex(index);
                    spaces.GetComponent<changePic>().ChangeSprite(index, 2);
                    Destroy(hit.transform.gameObject);
                    holder.GetComponent<WeaponSwitching>().SelectWeapon();
                }
            }

            else if (hit.transform.name == "colorSword(Clone)")
            {
                if ((childOb.name).Contains("empty"))
                {
                    childOb.transform.parent = unequipped.transform;
                    sword.transform.parent = holder.transform;
                    sword.transform.SetSiblingIndex(index);
                    spaces.GetComponent<changePic>().ChangeSprite(index, 3);
                    Destroy(hit.transform.gameObject);
                    holder.GetComponent<WeaponSwitching>().SelectWeapon();
                }
            }

            else if ((hit.transform.name == "Hoe(Clone)") || (hit.transform.name == "Hoe"))
            {
                if ((childOb.name).Contains("empty"))
                {
                    childOb.transform.parent = unequipped.transform;
                    hoe.transform.parent = holder.transform;
                    hoe.transform.SetSiblingIndex(index);
                    spaces.GetComponent<changePic>().ChangeSprite(index, 4);
                    Destroy(hit.transform.gameObject);
                    holder.GetComponent<WeaponSwitching>().SelectWeapon();
                }
            }

            //else if (hit.transform.name == "Cube")
            //{
            //inventory.GetComponent<inventorySpace>().addItem(50, "cube");
            //Destroy(hit.transform.gameObject);
            //}

            else if (hit.transform.name == "Farmer Phil")
            {
                dialogue = 0;
                speaker = "farmer";
                farmer.GetComponent<manTalk>().talking = true;
                qTime = 20.0f;
            }

            else if (hit.transform.name.Contains("FarmField_single"))
            {
                if (childOb.name == "Hoe")
                {
                    hit.transform.gameObject.GetComponent<MeshRenderer>().enabled = false;
                    hit.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
                    hit.transform.gameObject.GetComponent<respawnGrass>().respawn();
                    //qTxt.text = "grass";
                    inventory.GetComponent<inventorySpace>().addItem(2, "Wheat");
                    //qTime = 5.0f;
                }
            }

            else if (hit.transform.name == "Sir Biggles")
            {
                dialogue = 0;
                speaker = "biggles";
                qTime = 20.0f;
                trader.GetComponent<manTalk>().talking = true;
            }

            else if (hit.transform.name == "Lady Lisa")
            {
                dialogue = 0;
                qTime = 20.0f;
                speaker = "woman";
            }
            else if (hit.transform.name == "Wanderer")
            {
                dialogue = 0;
                qTime = 20.0f;
                speaker = "wanderer";
                wanderer.GetComponent<wanTalk>().talking = true;
            }
            else if (hit.transform.name == "King")
            {
                dialogue = 0;
                qTime = 20.0f;
                speaker = "king";
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        //if (other.GetComponent<Collider>().name == "player")
        //if (other.name == "player")
        //{ 
        if (other.GetComponent<Collider>().name == "Sir Biggles")
        {
            trader.GetComponent<manTalk>().talking = false;
        }
        if (other.GetComponent<Collider>().name == "Wanderer")
        {
            wanderer.GetComponent<wanTalk>().talking = false;
        }
        //Debug.Log("SET FALSE");
        //}
    }

    
    void CheckName()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if ((hit.transform.tag == "target") && (hit.transform.name != "hitBox"))
            {
                ehealthOb.SetActive(true);
                ehealthbar.SetHealth(hit.transform.gameObject.GetComponent<enemyHealth>().currentHealth);
                enemyName.text = hit.transform.gameObject.name;
            }
            else if (hit.transform.tag == "NPC")
            {
                npcName.text = hit.transform.gameObject.name;
            }
            else
            {
                npcName.text = "";
                enemyName.text = "";
                ehealthOb.SetActive(false);
            }
        }
    }
    
}
