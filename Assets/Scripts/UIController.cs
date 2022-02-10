using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas SwitchCanvas;
    public Canvas SignUpCanvas;
    public Canvas LoginCanvas;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObjectLoader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void gameObjectLoader() 
    {
        GameObject temp1 = GameObject.Find("SignSwitchCanvas");
        if (temp1 != null)
        {
            SwitchCanvas = temp1.GetComponent<Canvas>();
            if (SwitchCanvas == null)
            {
                Debug.LogError("Could not locate Canvas component on " + temp1.name);
            }
        }

        GameObject temp2 = GameObject.Find("SignUpCanvas");
        if (temp2 != null)
        {
            SignUpCanvas = temp2.GetComponent<Canvas>();
            if (SignUpCanvas == null)
            {
                Debug.LogError("Could not locate Canvas component on " + temp2.name);
            }
            SignUpCanvas.enabled = false;
        }


        GameObject temp3 = GameObject.Find("LoginCanvas");
        if (temp3 != null)
        {
            LoginCanvas = temp3.GetComponent<Canvas>();
            if (LoginCanvas == null)
            {
                Debug.LogError("Could not locate Canvas component on " + temp3.name);
            }
            LoginCanvas.enabled = false;
        }
    }

    //klikkevent a regisztráció canvasára
    public void signUpClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = true; } else { Debug.LogError("SignUpCanvas is null"); }
    }

    //klikkevent a login canvasára
    public void loginClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //klikkevent a login/signup "elosztó" canvasra
    public void backToSignHubButtonEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //akármilyen objektumra null ellenőrzés
    private bool isNull<T>(T obj)
    {
       return obj == null ? true : false;
    }
}
