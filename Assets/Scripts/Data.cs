using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data
{
    public string username = "";
    public string password = "";
    public string game_id = "";
    public bool is_host = false;
    public int player_position = 0;
    public int[] avatar = { 0, 0, 0 }; //[1,1,1] [sex, outfit, avatarindex]      -> { 0, 0, 0 } by default

    //public Vector3 real_position = new Vector3(0, 0, 0);
    //public Vector3 real_rotation = new Vector3(0, 0, 0);

    //public Vector3 control_position = new Vector3(0, 0, 0);
    //public Vector3 control_rotation = new Vector3(0, 0, 0);

    //public string avatar_string = "PLAYER_";
}
