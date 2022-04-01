using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        ConnectToServer();
    }

    void ConnectToServer()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("Try to connect to server...");
        GameObject.Find("TESTTEXT").GetComponent<Text>().text += "\nTry to connect to server...";
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Connected to Lobby.");
        GameObject.Find("TESTTEXT").GetComponent<Text>().text += "\nConnected to lobby";

    }

    public override void OnConnectedToMaster()
    {

        base.OnConnectedToMaster();

        RoomOptions room_options = new RoomOptions();
        room_options.MaxPlayers = 8;
        room_options.IsVisible = true;
        room_options.IsOpen = true;

        PhotonNetwork.JoinOrCreateRoom("Room2", room_options, TypedLobby.Default);
        Debug.Log("Connected to server.");
        GameObject.Find("TESTTEXT").GetComponent<Text>().text += "\nConnected to server";
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined to the room.");
        GameObject.Find("TESTTEXT").GetComponent<Text>().text += "\nJoined to the room.";
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        GameObject.Find("TESTTEXT").GetComponent<Text>().text += "\nOther player joined to the room.";
    }
}
