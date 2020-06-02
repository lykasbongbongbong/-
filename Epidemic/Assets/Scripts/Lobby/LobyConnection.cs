using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobyConnection : MonoBehaviour {
    [SerializeField] private LobbyNetworkManager networkManager = null;
    [SerializeField] private GameObject TeamUICanvas = null;

    private InputField ipInputField = null;
    private Button joinButton = null;
    private GameObject StartCanvas = null;

    private void OnEnable() {
        LobbyNetworkManager.OnClientConnected += HandleClientConnected;
        LobbyNetworkManager.OnClientDisconnected += HandleClientDisConnected;
    }

    private void Start() {
        ipInputField = transform.GetChild(1).GetChild(0).GetComponent<InputField>();
        joinButton = transform.GetChild(1).GetChild(1).GetComponent<Button>();
        StartCanvas = transform.parent.gameObject;
    }

    public void Host() {
        networkManager.StartHost();
        TeamUICanvas.SetActive(true);
        StartCanvas.SetActive(false);
    }

    public void Join() {
        string ip = ipInputField.text;
        networkManager.networkAddress = ip;
        networkManager.StartClient();
        joinButton.interactable = false;
    }

    private void HandleClientConnected() {
        joinButton.interactable = true;
        TeamUICanvas.SetActive(true);
        StartCanvas.SetActive(false);

        LobbyNetworkManager.OnClientConnected -= HandleClientConnected;
        LobbyNetworkManager.OnClientDisconnected -= HandleClientDisConnected;
    }

    private void HandleClientDisConnected() {
        joinButton.interactable = true;
    }
}
