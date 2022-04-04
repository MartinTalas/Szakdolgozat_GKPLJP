using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    private GameObject spawned_player; //player who spawned
    public override void OnJoinedRoom()
    {
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
}
