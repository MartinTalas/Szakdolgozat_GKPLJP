using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------

    public Canvas SwitchCanvas;
    public Canvas SignUpCanvas;
    public Canvas LoginCanvas;
    public Canvas GameChooserCanvas;

    //[SerializeField] VRInputField login_username;
    //[SerializeField] VRInputField login_password;
    //[SerializeField] VRInputField sign_up_username;
    //[SerializeField] VRInputField sign_up_password;
    //[SerializeField] VRInputField sign_up_aga_password;

    public VRInputField login_username;
    public VRInputField login_password;
    public VRInputField sign_up_username;
    public VRInputField sign_up_password;
    public VRInputField sign_up_aga_password;

    private DataBaseManager dataBaseManager; 

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INHERITED FROM MONOBEHAVIOUS ]---------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        this.gameObjectLoader();
        dataBaseManager = DataBaseManager.Instance;   
    }

    // Update is called once per frame
    void Update()
    {

    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------[ LOADERS AND OTHERS ]--------------------------------------------------------------------

    private void gameObjectLoader()
    {
        GameObject temp;
        //CANVAS [SIGNSWITCH]
        {
            temp = GameObject.Find("SignSwitchCanvas");
            if (temp != null)
            {
                SwitchCanvas = temp.GetComponent<Canvas>();
                if (SwitchCanvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //CANVAS [SIGNUP]
        {
            temp = GameObject.Find("SignUpCanvas");
            if (temp != null)
            {
                SignUpCanvas = temp.GetComponent<Canvas>();
                if (SignUpCanvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                SignUpCanvas.enabled = false;
            }
            temp = null;
        }

        //CANVAS [LOGIN]
        {
            temp = GameObject.Find("LoginCanvas");

            if (temp != null)
            {
                LoginCanvas = temp.GetComponent<Canvas>();
                if (LoginCanvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                LoginCanvas.enabled = false;
            }
            temp = null; 
        }

        //CANVAS [GAMECHOOSER]
        {
            temp = GameObject.Find("GameChooserCanvas");
            if (temp != null)
            {
                GameChooserCanvas = temp.GetComponent<Canvas>();
                if (SwitchCanvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                GameChooserCanvas.enabled = false; 
            }
            temp = null;
        }

        //INPUT
        {
            temp = GameObject.Find("UsernameInput");
            if (temp != null)
            {
                login_username = temp.GetComponent<VRInputField>();
                if (login_username == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //INPUT
        {
            temp = GameObject.Find("PasswordInput");
            if (temp != null)
            {
                login_password = temp.GetComponent<VRInputField>();
                if (login_password == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------[ CLICK EVENTS ]-----------------------------------------------------------------------

    //klikkevent a regisztráció canvasára
    public void signUpClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = true; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //klikkevent a login canvasára
    public void loginClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //klikkevent a login/signup "elosztó" canvasra
    public void backToSignHubButtonEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //klikkevent a game chooser canvasra
    public void goToJoinCanvas()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
    }

    //klikkevent a játékba belépéshez !!DELETED!! Replaced by goToCharacterSelectorScene (NE TÖRÖLD AZ ADATBÁZIS MIATT (LOGIN))
    /*public void loginToGameButtonEvent()
    {
        //check
        //dataBaseManager.loginUser(login_username.text.ToString(), login_password.text.ToString());
        SceneManager.LoadScene("RoomScene");
    }*/

    //klikkevent a játékba regisztráláshoz
    public void signUpToGameButtonEvent()
    {
        //check+reg
        goToCharacterSelectorScene();
    }

    //klikkevent a karakterválasztó scene-re
    public void goToCharacterSelectorScene()
    {
        SceneManager.LoadScene("CharacterSelectorScene");
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------[ PRIVATE CHECK FUNCTIONS AND MISCELLANEOUS FUNCTIONS ]----------------------------------------------------

    //akármilyen objektumra null ellenőrzés
    private bool isNull<T>(T obj)
    {
       return obj == null ? true : false;
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
