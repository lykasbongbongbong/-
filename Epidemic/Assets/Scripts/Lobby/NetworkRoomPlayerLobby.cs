using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkRoomPlayerLobby : NetworkBehaviour {
    [SyncVar(hook = nameof(HandleReadyStatusChanged))]
    public bool IsReady = false;

    private bool isLeader;

    public bool IsLeader {
        set {
            isLeader = value;
            //set start game button
        }
    }

    private LobbyNetworkManager room;
    private LobbyNetworkManager Room {
        get {
            if (room != null) return room;
            return room = NetworkManager.singleton as LobbyNetworkManager;
        }
    }

    public override void OnStartAuthority() {
        
    }

    public override void OnStartClient() {
        Room.RoomPlayers.Add(this);
        //UpdateDisplay() ;
    }

    public override void OnStopClient() {
        Room.RoomPlayers.Remove(this);
        //UpdateDisplay() ;
    }

    public void HandleReadyStatusChanged(bool oldValue, bool newValue) {
        //UpdateDisplay();
    }

    /*private void UpdateDisplay() {
        if (!hasAuthority) {
            foreach (var player in Room.RoomPlayers) {
                if (player.hasAuthority) {
                    player.UpdateDisplay();
                    break;
                }
            }

            return;
        }

        for (int i = 0; i < playerNameTexts.Length; i++) {
            playerNameTexts[i].text = "Waiting For Player...";
            playerReadyTexts[i].text = string.Empty;
        }

        for (int i = 0; i < Room.RoomPlayers.Count; i++) {
            playerNameTexts[i].text = Room.RoomPlayers[i].DisplayName;
            playerReadyTexts[i].text = Room.RoomPlayers[i].IsReady ?
                "<color=green>Ready</color>" :
                "<color=red>Not Ready</color>";
        }
    }*/

    public void HandleReadyToStart(bool b) {

    }

    [Command]
    private void CmdReadyUp() {

    }
}
