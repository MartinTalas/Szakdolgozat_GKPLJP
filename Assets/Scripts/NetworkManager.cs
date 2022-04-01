using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.GameVersion = "450663d7-f8a4-41e4-bbec-5eb49a985cf4";
        PhotonNetwork.ConnectUsingSettings();
        
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try to connect to server...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to server.");
        base.OnConnectedToMaster();

        RoomOptions room_options = new RoomOptions();
        room_options.MaxPlayers = 8;
        room_options.IsVisible = true;
        room_options.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room", room_options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined to the room.");
        base.OnJoinedRoom();
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
    }
}
