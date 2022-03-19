using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;
using Firebase.Database;

enum FIELDENUM //enum for the textfields [INPUTS]
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
    private FirebaseDatabase db;

    private JsonParser jsonParser;


    //TESTOBJECTS
    public Text TESTTEXT;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INHERITED FROM MONOBEHAVIOUS ]---------------------------------------------------------------

    // Awake is called first
    void Awake()
    {
        //dataBaseManager = DataBaseManager.Instance; // EZ OKOZZA A HIBÁT!!!!!!!!!
        jsonParser = JsonParser.Instance;
        
        //Set json to default
        Data default_data = new Data();
        jsonParser.toJson<Data>(default_data, "userdata");
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObjectLoader();

        dataBaseManager = DataBaseManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
       //TESTTEXT.text = dataBaseManager.result;
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

        //TESTING
        //TEXT [TESTTEXT]
        {
            temp = GameObject.Find("TESTTEXT");
            if (temp != null)
            {
                TESTTEXT = temp.GetComponent<Text>();
                if (TESTTEXT == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
            }
            temp = null;
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //-----------------------------------------------------------------------[ CLICK EVENTS ]-----------------------------------------------------------------------

    //-------------------------------------------------------[CANVAS CHANGE]
    //click event to the sign up canvas
    public void signUpClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = true; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        selectField(sign_up_username);
    }

    //click event to the login canvas
    public void loginClickEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        selectField(login_username);
    }

    //click event to the first canvas (back button)
    public void backToSignHubButtonEvent()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
    }

    //click event to join canvas
    public void goToJoinCanvas()
    {
        if (!isNull<Canvas>(SwitchCanvas)) { SwitchCanvas.enabled = false; } else { Debug.LogError("SwitchCanvas is null"); }
        if (!isNull<Canvas>(SignUpCanvas)) { SignUpCanvas.enabled = false; } else { Debug.LogError("SignUpCanvas is null"); }
        if (!isNull<Canvas>(LoginCanvas)) { LoginCanvas.enabled = false; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(GameChooserCanvas)) { GameChooserCanvas.enabled = true; } else { Debug.LogError("LoginCanvas is null"); }
        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); }
        selectField(game_id_input);
    }
    //-------------------------------------------------------[EOF CANVAS CHANGE]

    //-------------------------------------------------------[SCENE CHANGE]
    public void goToCharacterSelectorScene()
    {
        SceneManager.LoadScene("AvatarSelectorScene");
    }
    //-------------------------------------------------------[EOF SCENE CHANGE]

    //click event to login
    public async void loginToGameButtonEvent()
    {
        int result = -1;

        if (login_username.text.ToString().Length == 0 || login_password.text.ToString().Length == 0)
        {
            result = 3; //empty fields
        }
        else 
        {
            db = dataBaseManager.getConnection();
            try
            {
                await db.GetReference("player").Child(login_username.text.ToString())
                                        .Child("password")
                                        .GetValueAsync()
                                        .ContinueWith(task =>
                                        {
                                            if (task.IsCompleted)
                                            {
                                                Debug.Log("task.IsCompleted: Succeeded");
                                                DataSnapshot data_snapshot = task.Result;
                                                Debug.Log(task.Result.ToString());
                                                if (data_snapshot.Exists)
                                                {
                                                    Debug.Log(task.Result.ToString() + "completed");
                                                    if (data_snapshot.Value.Equals(login_password.text.ToString()))
                                                    {
                                                        result = 0; //succeeded
                                                        Debug.Log("LOGIN SUCCEEDED");
                                                    }
                                                    else
                                                    {
                                                        result = 1; //wrong password
                                                        Debug.Log("LOGIN FAILED");
                                                    }

                                                }
                                                else
                                                {
                                                    result = 2; //sign up first
                                                    Debug.Log(task.Result.ToString() + " -> NOT EXISTS");
                                                }
                                            }
                                            else
                                            {
                                                Debug.LogError("task.IsCompleted: Failed");
                                            }


                                        });
            }
            catch (Exception ex)
            {

            }
            
            if(result == 0)
            {
                Data data = new Data();
                data.username = login_username.text.ToString();
                data.password = login_password.text.ToString();

                jsonParser.toJson<Data>(data, "userdata");
                goToJoinCanvas();
            } 
        }

        TESTTEXT.text = result.ToString();
    }

    //click event to sign up
    public void signUpToGameButtonEvent()
    {
        //check+reg
        goToJoinCanvas();
    }

    public void join() // SET GAMEID            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]
    {
        int dummy = 420;
        saveGameID(dummy);
        goToCharacterSelectorScene();
    }

    public void Host() // SET GAMEID            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]            [TODO]
    {
        int dummy = 420;
        saveGameID(dummy);
        goToCharacterSelectorScene();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //----------------------------------------------------------------------[ DATA FUNCTIONS ]----------------------------------------------------------------------

    private void saveGameID(int game_id)
    {
        Data data = jsonParser.toObject<Data>("userdata");
        data.game_id = game_id;
        jsonParser.toJson<Data>(data, "userdata");
    }


    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //--------------------------------------------------------------------[ KEYBOARD FUNCTIONS ]--------------------------------------------------------------------

    //handle selected text field
    public void selectField(VRInputField field)
    {
        inputHightlight(field);//highlight the selected text field

        if (!isNull<Canvas>(KeyboardCanvas)) { KeyboardCanvas.enabled = true; } else { Debug.LogError("SwitchCanvas is null"); } //activate keyboard 

        switch (field.name) 
        {
            case "UsernameInput":
                field_enum = FIELDENUM.LOGIN_USERNAME;
                keyboard_input_field.text = login_username.text;
                break;

            case "PasswordInput":
                field_enum = FIELDENUM.LOGIN_PASSWORD;
                keyboard_input_field.text = login_password.text;
                break;

            case "SignUpUsernameInput":
                field_enum = FIELDENUM.SIGN_UP_USERNAME;
                keyboard_input_field.text = sign_up_username.text;
                break;

            case "SignUpPasswordInput":
                field_enum = FIELDENUM.SIGN_UP_PASSWORD;
                keyboard_input_field.text = sign_up_password.text;
                break; 

            case "SignUpPasswordAgainInput":
                field_enum = FIELDENUM.SIGN_UP_PASSWORD_AGAIN;
                keyboard_input_field.text = sign_up_again_password.text;
                break;

            case "GameIDInput":
                field_enum = FIELDENUM.GAME_CODE;
                keyboard_input_field.text = game_id_input.text;
                break;

            default:
                field_enum = FIELDENUM.NON;
                keyboard_input_field.text = "";
                break;
        }

        //keyboard_input_field.text = ""; //clear the keyboard field
    }

    //handle changes in the keyboard text field
    public void updateTextFields()
    {
        string temp = keyboard_input_field.text;

        if (field_enum != FIELDENUM.NON )//&& temp.Length > 0) // without this: works! (!?)
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

                case FIELDENUM.GAME_CODE:
                    game_id_input.text = temp;
                    break;

                default:
                    field_enum = FIELDENUM.NON;
                    break;
            }
        }
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INPUT HIGHLIGHTING FUNCTION ]----------------------------------------------------------------
    
    // [INPUT FIELDS]:

    /*
        login_username;
        login_password;
        sign_up_username;
        sign_up_password;
        sign_up_again_password;
        game_id_input;
    */

    private void inputHightlight(VRInputField highlight_this)
    {
        switch (highlight_this.name)
        {
            case "UsernameInput":
                login_username.image.color = new Color32(202,229,255,255);// [HIGHLIGHTED]>-----[*]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;

            case "PasswordInput":
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(202, 229, 255, 255);// [HIGHLIGHTED]>-----[*]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;

            case "SignUpUsernameInput":
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(202, 229, 255, 255);// [HIGHLIGHTED]>-----[*]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;

            case "SignUpPasswordInput":
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(202, 229, 255, 255);// [HIGHLIGHTED]>-----[*]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;

            case "SignUpPasswordAgainInput":
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(202, 229, 255, 255);// [HIGHLIGHTED]>-----[*]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;

            case "GameIDInput":
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(202, 229, 255, 255);// [HIGHLIGHTED]>-----[*]
                break;

            default:
                login_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                login_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_username.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                sign_up_again_password.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                game_id_input.image.color = new Color32(255, 255, 255, 255);// [DEFAULT]
                break;
        }

    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------[ PRIVATE CHECK FUNCTIONS AND MISCELLANEOUS FUNCTIONS ]----------------------------------------------------

    //null check for any object 
    private bool isNull<T>(T obj)
    {
       return obj == null ? true : false;
    }
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
