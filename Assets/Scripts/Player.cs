using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player: NetworkBehaviour
{
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //------------------------------------------------------------------------[ VARIABLESS ]------------------------------------------------------------------------

    public int id;
    public string username;
    public string password;
    public int score;
    public List<int> achievements; // by achievement id
    public bool isSpeaker;
    public bool is_host;
    public GameObject avatar;
    public int[] avatar_array = new int[3];
    public string game_id;

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}
