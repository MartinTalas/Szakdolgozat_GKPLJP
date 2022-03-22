using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public string username = "";
    public string password = "";
    public string game_id = "";
    public bool is_host = false;
    public int[] avatar = { 0, 0, 0 }; //[1,1,1] [sex, outfit, avatarindex]      -> { 0, 0, 0 } by default
}
