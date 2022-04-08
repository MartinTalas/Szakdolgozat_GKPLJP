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

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INHERITED FROM MONOBEHAVIOUS ]---------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rating = Rating.Instance;
        dataBaseManager = DataBaseManager.Instance;
        jsonParser = JsonParser.Instance;

        data = jsonParser.toObject<Data>("userdata.json");
        //FirebaseDatabase.DefaultInstance.GetReference("current_speaker").Child(data.game_id).ValueChanged += currentSpeakerChanged();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    private async void confirmation()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {  
            db = dataBaseManager.getConnection();
            try
            {
                int pnts = current_speaker_points + rating.getVoteRate();
                await db.GetReference("points").Child(current_speaker).SetValueAsync(pnts);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception: " + ex);
            }
            
        }
    }

    private async void setCurrentSpeaker()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }
        else
        {
            db = dataBaseManager.getConnection();
            try
            {
                await db.GetReference("current_speaker").Child(data.game_id).SetValueAsync(data.username);
            }
            catch (Exception ex)
            {
                Debug.Log("Exception: " + ex);
            }

        }
    }

    private async void getCurrentSpeaker()
    {
        //await;dblistener
        current_speaker = "";
    }


    private async void getCurrentSpeakerPoints()
    {
        //await;dblistener
        current_speaker_points = -1;
    }
    /*
    private EventHandler<ValueChangedEventArgs> currentSpeakerChanged()
    {
        getCurrentSpeaker();
        //return new EventHandler<ValueChangedEventArgs>();
    }*/
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------

    public void confirm()
    {
        confirmation();
    }
}
