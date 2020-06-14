using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.SceneManagement;

public class LobbyNetworkManager : NetworkManager {
    [SerializeField] private int minPlayers = 2;

    [Scene] [SerializeField] private string lobby = string.Empty;
    [SerializeField] private NetworkRoomPlayerLobby roomPlayerPrefab = null;

    public static event Action OnClientConnected;
    public static event Action OnClientDisconnected;

    public List<NetworkRoomPlayerLobby> RoomPlayers { get; } = new List<NetworkRoomPlayerLobby>();

    public override void OnClientConnect(NetworkConnection conn) {
        base.OnClientConnect(conn);
        OnClientConnected?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn) {
        base.OnClientDisconnect(conn);
        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn) {
        if(numPlayers >= maxConnections) {
            conn.Disconnect();
            return;
        }

        if(SceneManager.GetActiveScene().name != lobby) {
            conn.Disconnect();
            return;
        }
    }

    public override void OnServerAddPlayer(NetworkConnection conn) {
        if(SceneManager.GetActiveScene().name == lobby) {
            bool isLeader = RoomPlayers.Count == 0;
            NetworkRoomPlayerLobby roomPlayerInstance = Instantiate(roomPlayerPrefab);
            roomPlayerInstance.IsLeader = isLeader;
            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }

    public override void OnServerDisconnect(NetworkConnection conn) {
        if(conn.identity != null) {
            var player = conn.identity.GetComponent<NetworkRoomPlayerLobby>();
            RoomPlayers.Remove(player);
            UpdatePlayersReadyState();
        }
        base.OnServerDisconnect(conn);
    }

    public override void OnStopServer() {
        RoomPlayers.Clear();
    }

    public void UpdatePlayersReadyState() {
        foreach(var player in RoomPlayers) {
            player.HandleReadyToStart(IsReadyToStart());
        }
    }

    private bool IsReadyToStart() {
        if (numPlayers < minPlayers) return false;

        foreach(var player in RoomPlayers) {
            if((!player.IsReady)) {
                return false;
            }
        }
        return true;
    }
}
