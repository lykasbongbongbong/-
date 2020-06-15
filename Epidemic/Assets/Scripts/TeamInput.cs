using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UMA.CharacterSystem;

public class TeamInput : MonoBehaviour {
    public int playerNum;

    [Header("UI")]
    public InputField inputField;
    public Button readyButton;
    public Text readyText;
    public Text anotherReadyText;
    public Text characterChoiceText;
    public DynamicCharacterAvatar avatar;

    private string inputName;
    private int characterIndex = 1;

    // Start is called before the first frame update
    void Start() {
        readyText.enabled = false;
        readyButton.interactable = false;
        characterChoiceText.text = characterIndex.ToString();
    }

    // Update is called once per frame
    void Update() {
        Debug.Log(avatar.activeRace.name);
    }

    public void CharacterNext() {
        characterIndex = (characterIndex == 2) ? 1 : characterIndex+1;
        characterChoiceText.text = characterIndex.ToString();
        UpdateCharacter();
    }

    public void CharacterPrevious() {
        characterIndex = (characterIndex == 1) ? 2 : characterIndex-1;
        characterChoiceText.text = characterIndex.ToString();
        UpdateCharacter();
    }

    private void UpdateCharacter() {
        if(characterIndex==1) {
            avatar.ChangeRace("HumanMale");
        }
        else {
            avatar.ChangeRace("HumanFemale");
        }
    }

    public void UpdateInputField(string str) {
        readyButton.interactable = !string.IsNullOrEmpty(str);
        inputName = str;
    }

    public void Ready() {
        if(!readyText.enabled) {
            if (playerNum == 1) {
                SystemVariables.player1.name = inputName;
                SystemVariables.player1.playerTypeIndex = characterIndex;
            }
            else {
                SystemVariables.player2.name = inputName;
                SystemVariables.player2.playerTypeIndex = characterIndex;
            }
            readyText.enabled = true;

            if (anotherReadyText.enabled) {
                SceneManager.LoadScene("_scene");
                Debug.Log("Change Scene");
            }
        }
        else {
            readyText.enabled = false;
        }
    }
}
