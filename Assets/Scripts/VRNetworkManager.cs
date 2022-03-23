using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Mirror;

public class VRNetworkManager : NetworkManager
{

    GameObject player;
    [SerializeField] public int min_players = 2;
    [SerializeField] public int max_players = 8;
    [SerializeField] private GamePlayer game_player_prefab;
    public List<GamePlayer> game_players { get; } = new List<GamePlayer>();
}
