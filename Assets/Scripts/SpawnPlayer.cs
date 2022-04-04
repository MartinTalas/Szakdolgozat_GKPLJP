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

    public override void OnJoinedRoom()
    {
        setData();

        base.OnJoinedRoom();
        Debug.Log("New player joined to the room!");
        
        spawned_player = PhotonNetwork.Instantiate("PLAYER", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        Debug.Log("Player left!");

        PhotonNetwork.Destroy(spawned_player);
    }

    private void setData()
    {
        jsonParser = JsonParser.Instance;
        data = jsonParser.toObject<Data>("userdata");
    }
}
