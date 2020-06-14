using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamInput : MonoBehaviour {
    public int playerNum;

    [Header("UI")]
    public InputField inputField;
    public Button readyButton;
    public Text readyText;
    public Text anotherReadyText;

    private string inputName;

    // Start is called before the first frame update
    void Start() {
        readyText.enabled = false;
        readyButton.interactable = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void UpdateInputField(string str) {
        readyButton.interactable = !string.IsNullOrEmpty(str);
        inputName = str;
    }

    public void Ready() {
        if(!readyText.enabled) {
            if (playerNum == 1) {
                SystemVariables.player1.name = inputName;
            }
            else {
                SystemVariables.player2.name = inputName;
            }
            readyText.enabled = true;

            if (anotherReadyText.enabled) {
                //SceneManager.LoadScene("Game");
                Debug.Log("Change Scene");
            }
        }
        else {
            readyText.enabled = false;
        }
    }
}
