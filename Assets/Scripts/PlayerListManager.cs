using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListManager
{
    public List<Data> PLAYERS = new List<Data>();
    
    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------[ SINGLETON PATTERN ]--------------------------------------------------------------------


    private static readonly Lazy<PlayerListManager> lazy = new Lazy<PlayerListManager>(() => new PlayerListManager());

    public static PlayerListManager Instance { get { return lazy.Value; } }

    private PlayerListManager()
    {

    }

    //--------------------------------------------------------------------------------------------------------------------------------------------------------------
}