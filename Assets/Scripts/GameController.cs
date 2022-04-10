using Firebase.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------

    private Data data;
    private JsonParser jsonParser;
    private Rating rating;
    private DataBaseManager dataBaseManager;
    private FirebaseDatabase db;
    private string current_speaker = "ERR";
    private int current_speaker_points = 0;
    private bool is_voted = false;
    private bool is_last = false;
    private List<string> player_list;

    public Canvas rate_canvas;
    public Canvas menu_canvas;
    public Canvas speaker_canvas;
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INHERITED FROM MONOBEHAVIOUS ]---------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        canvasLoader();

        rating = Rating.Instance;
        dataBaseManager = DataBaseManager.Instance;
        jsonParser = JsonParser.Instance;

        data = jsonParser.toObject<Data>("userdata");
        FirebaseDatabase.DefaultInstance.GetReference("current_speaker").Child(data.game_id).ValueChanged += currentSpeakerChanged();
        FirebaseDatabase.DefaultInstance.GetReference("games").Child(data.game_id).ChildAdded += playerListChanged();

        player_list = new List<string>();
    }

    bool firstset = true;
    // Update is called once per frame
    void Update()
    {
        /*try
        {
            
            while (firstset)
            {
                setFirstSpeaker();
                firstset = false;
                Debug.Log("FIRST: SET");
            }
        }
        catch (Exception ex)
        {
            Debug.Log("FIRST: null");
        }*/
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ RATING FUNCTIONS ]---------------------------------------------------------------------

    public void rateOne()
    {
        rating.rateOneR();
    }
    public void rateTwo()
    {
        rating.rateTwoR();
    }
    public void rateThree()
    {
        rating.rateThreeR();
    }
    public void rateFour()
    {
        rating.rateFourR();
    }
    public void rateFive()
    {
        rating.rateFiveR();
    }

    public void hoverOne()
    {
        rating.hoverOneR();
    }
    public void hoverTwo()
    {
        rating.hoverTwoR();
    }
    public void hoverThree()
    {
        rating.hoverThreeR();
    }
    public void hoverFour()
    {
        rating.hoverFourR();
    }
    public void hoverFive()
    {
        rating.hoverFiveR();
    }

    public void hoverExit()
    {
        rating.hoverExitR();
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ DATABASE MANAGING ]--------------------------------------------------------------------

    private async void getPlayerList()
    {
        try 
        {
            /*db = dataBaseManager.getConnection();
            await db.GetReference("games").Child(data.game_id)
                                           .GetValueAsync()
                                           .ContinueWith(task =>
                                           {
                                               if (task.IsCompleted)
                                               {
                                                   Debug.Log("task.IsCompleted: Succeeded [get playerList]");
                                                   DataSnapshot data_snapshot = task.Result;

                                                   if (data_snapshot.Exists)
                                                   {
                                                       Debug.Log(task.Result.ToString());
                                                       var dts = data_snapshot.Value as Dictionary<string, object>;

                                                       player_list.Clear();
                                                       foreach(var item in dts)
                                                       {
                                                           player_list.Add(item.Key);
                                                           Debug.Log("Players:" + item.Key);
                                                       }

                                                   }
                                                   else
                                                   {
                                                       Debug.Log(task.Result.ToString() + " ERROR");
                                                   }
                                               }
                                               else
                                               {
                                                   Debug.LogError("task.IsCompleted: Failed [get playerlist]");
                                               }

                                           });*/
        }
        catch (Exception ex)
        {
            Debug.Log("Exception: " + ex);
            GameObject.Find("TESTTEXT").GetComponent<Text>().text = "GETPLAYERLIST EX";
        }
    }

    private async void confirmation()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {  
            /*db = dataBaseManager.getConnection();
            try
            {
                int pnts = current_speaker_points + rating.getVoteRate();
                await db.GetReference("points").Child(current_speaker).SetValueAsync(pnts);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception: " + ex);
            }
            */
        }
    }

    private async void setCurrentSpeaker(string speaker)
    {
        /*if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            db = dataBaseManager.getConnection();
            try
            {
                await db.GetReference("current_speaker").Child(data.game_id).SetValueAsync(speaker);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception: " + ex);
            }

        }

        canvasChanger();
        */
    }

    private async void getCurrentSpeaker()
    {
        /*db = dataBaseManager.getConnection();
        await db.GetReference("current_speaker").Child(data.game_id).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                Debug.Log("task.IsCompleted: Succeeded [CURRENT SPEAKER]");
                DataSnapshot data_snapshot = task.Result;

                if (data_snapshot.Exists)
                {
                    Debug.Log("GETCURRENT" + data_snapshot.Value.ToString());
                }
            }
        });*/
    }


    private async void getCurrentSpeakerPoints()
    {
        //await;dblistener
        //current_speaker_points = -1;
    }
    
    private EventHandler<ValueChangedEventArgs> currentSpeakerChanged()
    {
    //    getCurrentSpeaker();
       // is_voted = true;

        return null; //dummy return

    }
    
    private EventHandler<ChildChangedEventArgs> playerListChanged()
    {
        //getPlayerList();
        return null; //dummy return
    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void confirm()
    {
        /*getPlayerList();
        if (!is_voted)
        {
            confirmation();
            is_voted = false;

            canvasChanger();
        }*/
    }

    public void next()
    {
        /*for (int i = 0; i < player_list.Count; i++)
        {
            is_last = (i == player_list.Count-1) ? true : false;
        }
        string n_speaker = "";
        
        for(int i = 0; i < player_list.Count; i++)
        {
            if(player_list[i] == data.username && !is_last)
            {
                n_speaker = player_list[i + 1];
            }
        }
        setCurrentSpeaker(n_speaker);
        canvasChanger();*/
    }

    public void menu()
    {
        rate_canvas.enabled = false;
        menu_canvas.enabled = true;
        speaker_canvas.enabled = false;
    }

    public void back()
    {
        if (current_speaker == data.username)
        {
            rate_canvas.enabled = false;
            menu_canvas.enabled = false;
            speaker_canvas.enabled = true;
        }
        else
        {
            rate_canvas.enabled = true;
            menu_canvas.enabled = false;
            speaker_canvas.enabled = false;
        }
    }

    public void quit()
    {
        Application.Quit();
    }

    private void canvasLoader()
    {
        //getPlayerList();
        GameObject temp;

        //CANVAS [CURRENT]
        {
            temp = GameObject.Find("CurrentCanvas");
            if (temp != null)
            {
                speaker_canvas = temp.GetComponent<Canvas>();
                if (speaker_canvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                speaker_canvas.enabled = true;
            }
            temp = null;
        }
        
        //CANVAS [RATE]
        {
            temp = GameObject.Find("RateCanvas");
            if (temp != null)
            {
                rate_canvas = temp.GetComponent<Canvas>();
                if (rate_canvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                 rate_canvas.enabled = false;
            }
            temp = null;
        }
        
        //CANVAS [MENU]
        {
            temp = GameObject.Find("GameMenuCanvas");
            if (temp != null)
            {
                menu_canvas = temp.GetComponent<Canvas>();
                if (menu_canvas == null)
                {
                    Debug.LogError("Could not locate Canvas component on " + temp.name);
                }
                menu_canvas.enabled = false;
            }
            temp = null;
        }
    }

    private void canvasChanger()
    {
        /*if (current_speaker == data.username)
        {
            speaker_canvas.enabled = true;
            rate_canvas.enabled = false;
        }
        else
        {
            speaker_canvas.enabled = false;
            rate_canvas.enabled = true;
        }*/
    }

    private void setFirstSpeaker()
    {
        //current_speaker = player_list[0];

        //setCurrentSpeaker(current_speaker);
        //canvasChanger();
    }
}
