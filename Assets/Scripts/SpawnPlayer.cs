using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayer : MonoBehaviourPunCallbacks
{
    private GameObject spawned_player; //player who spawned
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        spawned_player = PhotonNetwork.Instantiate("Spwned player", transform.position, transform.rotation);
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        PhotonNetwork.Destroy(spawned_player);
    }
}
