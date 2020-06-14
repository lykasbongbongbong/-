using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamUIManager : MonoBehaviour {
    public GameObject UMA_Player;
    private GameObject InputIDPanel;
    private InputField IDInput;
    private GameObject IDErrorMessage;
    private bool start;

    // Start is called before the first frame update
    void Start() {
        InputIDPanel = transform.GetChild(1).gameObject;
        IDInput = InputIDPanel.transform.GetChild(2).GetComponent<InputField>();
        IDErrorMessage = InputIDPanel.transform.GetChild(1).gameObject;

        IDErrorMessage.SetActive(false);
        UMA_Player.SetActive(false);
        start = false;
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void SubmitID() {
        if(IDInput.text.Length == 0) {
            IDErrorMessage.SetActive(true);
        }
        else {
            //SystemVariables.usernames.Add(IDInput.text);
            InputIDPanel.SetActive(false);
            UMA_Player.SetActive(true);
            start = true;
        }
    }

    public void AddToTeam() {

    }
}
