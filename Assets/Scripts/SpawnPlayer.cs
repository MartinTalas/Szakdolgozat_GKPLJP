using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    private GameObject spawned_player; //player who spawned
    private Data data; //data for avatars and positioning
    private JsonParser jsonParser; //handle json
    private int position; //position (AS GAME QUEUE)
    private Vector3 real_position = new Vector3(0, 0, 0);
    private Vector3 real_rotation = new Vector3(0, 0, 0);
    private GameObject camera; //camera
    private string avatar = "PLAYER_";

    public override void OnJoinedRoom()
    {
        setData();

        base.OnJoinedRoom();
        Debug.Log("New player joined to the room!");

        spawned_player = PhotonNetwork.Instantiate(avatar, real_position, UnityEngine.Quaternion.Euler(real_rotation));//transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("Player left!");

        PhotonNetwork.Destroy(spawned_player);
    }

    private void setData()
    {
        camera = GameObject.Find("CameraRig");

        jsonParser = JsonParser.Instance;
        data = jsonParser.toObject<Data>("userdata");

        position = data.player_position;

        switch(position)
        {
            case 1:
                real_rotation = new Vector3(0, 0, 0);
                real_position = new Vector3(0, 0, -2.01f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(0, 1.6f, -1.87f);
                break;
            case 2:
                real_rotation = new Vector3(0, 270, 0);
                real_position = new Vector3(1.303125f, 0, -0.62f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(1.17f, 1.6f, -0.66f);
                break;
            case 3:
                real_rotation = new Vector3(0, 90, 0);
                real_position = new Vector3(-1.356875f, 0, -0.62f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(-1.18f, 1.6f, -0.66f);
                break;
            case 4:
                real_rotation = new Vector3(0, 270, 0);
                real_position = new Vector3(1.303125f, 0, 1.25f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(1.17f, 0, 1.24f);
                break;
            case 5:
                real_rotation = new Vector3(0, 90, 0);
                real_position = new Vector3(-1.356875f, 0, 1.25f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(-1.18f, 1.6f, 1.24f);
                break;
            case 6:
                real_rotation = new Vector3(0, 270, 0);
                real_position = new Vector3(1.303125f,0, 1.25f); 
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(1.17f, 1.6f, 3.15f);
                break;
            case 7:
                real_rotation = new Vector3(0, 90, 0);
                real_position = new Vector3(-1.356875f, 0, 3.15f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(-1.18f, 1.6f, 3.15f);
                break;
            case 8:
                real_rotation = new Vector3(0, 180, 0);
                real_position = new Vector3(0, 0, 3.15f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                camera.transform.position = new Vector3(0, 1.6f, 4.35f);
                break;
            default:
                real_rotation = new Vector3(0, 0, 0);
                real_position = new Vector3(-1.356875f, -100, 1.25f);
                camera.transform.rotation = UnityEngine.Quaternion.Euler(real_rotation);
                break;
        }

        string sex = "", outfit = "", index = "";

        if (data.avatar[0] == 0) //female
        {
            sex = "0";

            if (data.avatar[1] == 0) //casual
            {
                outfit = "0";
            }
            else //elegant
            {
                outfit = "1";
            }
        }
        else //male
        {
            sex = "1";

            if (data.avatar[1] == 0) //casual
            {
                outfit = "0";
            }
            else //elegant
            {
                outfit = "1";
            }
        }

        avatar += sex;
        avatar += outfit;
        avatar += data.avatar[2].ToString();
    }
}
