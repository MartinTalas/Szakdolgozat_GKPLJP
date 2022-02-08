using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testBTNscript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void getColor()//DEBUG
    {
        GameObject.Find("TestButton").GetComponentInChildren<Text>().text = "It just works!";
    }
}
