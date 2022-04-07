using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------
    
    Rating rating;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------[ INHERITED FROM MONOBEHAVIOUS ]---------------------------------------------------------------

    // Start is called before the first frame update
    void Start()
    {
        rating = Rating.Instance;
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

}
