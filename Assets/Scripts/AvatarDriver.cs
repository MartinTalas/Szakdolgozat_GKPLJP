using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvatarDriver : MonoBehaviour
{
    //temporapy avatar list (for singleton AvatarManager)
    public GameObject[] casual_females = new GameObject[8];
    public GameObject[] casual_males = new GameObject[8];
    public GameObject[] elegant_females = new GameObject[8];
    public GameObject[] elegant_males = new GameObject[8];

    //avatar for first load!!! [Casual female]
    public GameObject firstLoader;

    AvatarManager avatar_manager;
    // Start is called before the first frame update
    void Start()
    {
        //build singleton (sealed) AvatarManager class
        avatar_manager = AvatarManager.Instance;
        avatar_manager.buildLists(casual_females, casual_males, elegant_females, elegant_males);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //click event for next avatar
    public void toRight()
    {
        firstLoader.SetActive(false);
        avatar_manager.currentAvatar(true);
        avatar_manager.setPreview();
    }

    //click event for previous avatar
    public void toLeft()
    {
        firstLoader.SetActive(false);
        avatar_manager.currentAvatar(false);
        avatar_manager.setPreview();
    }

    //set sex ("gender") property
    public void setSexProperty()
    {
        bool sex = avatar_manager.getProperties()[0], outfit = avatar_manager.getProperties()[1];
        firstLoader.SetActive(false);
        if (sex)
        {
            sex = false;
            GameObject.Find("SexButton").GetComponentInChildren<Text>().text = "Female";
        }
        else
        {
            sex = true;
            GameObject.Find("SexButton").GetComponentInChildren<Text>().text = "Male";
        }

        avatar_manager.setProperties(sex, outfit);
        avatar_manager.setPreview();
    }

    //set outfit property
    public void setOutfitProperty()
    {
        bool sex = avatar_manager.getProperties()[0], outfit = avatar_manager.getProperties()[1];
        firstLoader.SetActive(false);
       
        if (outfit)
        {
            outfit = false;
            GameObject.Find("OutfitButton").GetComponentInChildren<Text>().text = "Casual";
        }
        else
        {
            outfit = true;
            GameObject.Find("OutfitButton").GetComponentInChildren<Text>().text = "Elegant";
        }

        avatar_manager.setProperties(sex, outfit);
        avatar_manager.setPreview();
    }

    //Ok button: load the room scene!!!!
    public void ok()
    {

    }
}
