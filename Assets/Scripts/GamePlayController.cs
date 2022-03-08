using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FullUser
{
    Player player;
    //Avatar avatar;
}
public class GamePlayController : MonoBehaviour
{
    List<FullUser> players = new List<FullUser>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerLimitChecker();
    }

    void playerLimitChecker()
    {
        if(players.Count > 8)
        {
            //TODO: FULL
        }
    }
}
