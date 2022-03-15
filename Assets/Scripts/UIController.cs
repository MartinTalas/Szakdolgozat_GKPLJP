using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

enum FIELDENUM
{
    LOGIN_USERNAME,
    LOGIN_PASSWORD,
    SIGN_UP_USERNAME,
    SIGN_UP_PASSWORD,
    SIGN_UP_PASSWORD_AGAIN,
    GAME_CODE,
    NON
}

public class UIController : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------

    //public static UIController Instance { get; private set; }

    public Canvas SwitchCanvas;
    public Canvas SignUpCanvas;
    public Canvas LoginCanvas;
    public Canvas GameChooserCanvas;
    public Canvas KeyboardCanvas;

    public VRInputField login_username;
    public VRInputField login_password;
    public VRInputField sign_up_username;
    public VRInputField sign_up_password;
    public VRInputField sign_up_again_password; 
    public VRInputField game_id_input; //GameIDInput

    public VRInputField keyboard_input_field;
    private static FIELDENUM field_enum;

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

    // Awake is called first
    void Awake()
    {
       /*
       if (Instance == null)
       {
            Instance = this;
            Debug.Log("ONCE");
       }
       */
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

        //CANVAS [KEYBOARD]
        {
            temp = GameObject.Find("KeyboardCanvas");
            if (temp != null)
            {
                KeyboardCanvas = temp.GetComponent<Canvas>();
                if (KeyboardCanvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                KeyboardCanvas.enabled = false;
            }
            temp = null;
        }

        //INPUT [LOGIN.USERNAME]
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

        //INPUT [LOGIN.PASSWORD]
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

        //INPUT [SIGNUP.USERNAME]
        {
            temp = GameObject.Find("SignUpUsernameInput");
            if (temp != null)
            {
                sign_up_username = temp.GetComponent<VRInputField>();
                if (sign_up_username == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //INPUT [SIGNUP.PASSWORD]
        {
            temp = GameObject.Find("SignUpPasswordInput");
            if (temp != null)
            {
                sign_up_password = temp.GetComponent<VRInputField>();
                if (sign_up_password == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //INPUT [SIGNUP.PASSWORD.AGAIN]
        {
            temp = GameObject.Find("SignUpPasswordAgainInput");
            if (temp != null)
            {
                sign_up_again_password = temp.GetComponent<VRInputField>();
                if (sign_up_again_password == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //INPUT [KEYBOARD]
        {
            temp = GameObject.Find("KeyboardInput");
            if (temp != null)
            {
                keyboard_input_field = temp.GetComponent<VRInputField>();
                if (keyboard_input_field == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }

        //INPUT [GAMEID]
        {
            temp = GameObject.Find("GameIDInput");
            if (temp != null)
            {
                game_id_input = temp.GetComponent<VRInputField>();
                if (game_id_input == null)
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
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
    }

    //klikkevent a login canvasára
    public void loginClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
    }

    //klikkevent a login/signup "elosztó" canvasra
    public void backToSignHubButtonEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
    }

    //klikkevent a game chooser canvasra
    public void goToJoinCanvas()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
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
        SceneManager.LoadScene("AvatarSelectorScene");
    }


    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------[ KEYBOARD FUNCTIONS ]--------------------------------------------------------------------


    public void selectField(VRInputField field)
    {
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }

        keyboard_input_field.text = field.text;
        Debug.Log(field.name);
        switch (field.name) 
        {
            case "UsernameInput":
                field_enum = FIELDENUM.LOGIN_USERNAME;
                Debug.Log(field_enum);
                break;

            case "PasswordInput":
                field_enum = FIELDENUM.LOGIN_PASSWORD;
                Debug.Log(field_enum);
                break;

            case "SignUpUsernameInput":
                field_enum = FIELDENUM.SIGN_UP_USERNAME;
                break;

            case "SignUpPasswordInput":
                field_enum = FIELDENUM.SIGN_UP_PASSWORD;
                break; 

            case "SignUpPasswordAgainInput":
                field_enum = FIELDENUM.SIGN_UP_PASSWORD_AGAIN;
                break;
            
            default:
                field_enum = FIELDENUM.NON;
                break;
        }

        Debug.Log(field_enum);
    }


    public void updateTextFields()
    {
        string temp = keyboard_input_field.text;
        if (field_enum != FIELDENUM.NON && temp.Length > 0)
        {
            switch (field_enum)
            {
                case FIELDENUM.LOGIN_USERNAME:
                    login_username.text = temp;
                    break;

                case FIELDENUM.LOGIN_PASSWORD:
                    login_password.text = temp;
                    break;

                case FIELDENUM.SIGN_UP_USERNAME:
                    sign_up_username.text = temp;
                    break;

                case FIELDENUM.SIGN_UP_PASSWORD:
                    sign_up_password.text = temp;
                    break;

                case FIELDENUM.SIGN_UP_PASSWORD_AGAIN:
                    sign_up_again_password.text = temp;
                    break;

                default:
                    field_enum = FIELDENUM.NON;
                    break;
            }
        }
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
