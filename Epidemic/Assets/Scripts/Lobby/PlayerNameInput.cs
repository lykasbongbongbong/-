using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInput : MonoBehaviour {
    private InputField NameInputField = null;
    private Button NextButton = null;

    public static string DisplayName { get; private set;}

    private const string PlayerPrefsNameKey = "PlayerName";

    private void Start() {
        NameInputField = transform.GetChild(0).GetComponent<InputField>();
        NextButton = transform.GetChild(1).GetComponent<Button>();
        SetUpInputField();
    }

    private void SetUpInputField() {
        if(!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }
        string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);
        NameInputField.text = defaultName;
        SetPlayerName(defaultName);
    }

    public void SetPlayerName(string name) {
        NextButton.interactable = !string.IsNullOrEmpty(name);
    }

    public void SavePlayerName() {
        DisplayName = NameInputField.text;
        PlayerPrefs.SetString(PlayerPrefsNameKey, DisplayName);
    }
}
