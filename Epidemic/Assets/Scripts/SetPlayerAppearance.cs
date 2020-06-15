using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMA.CharacterSystem;

public class SetPlayerAppearance : MonoBehaviour {
    private DynamicCharacterAvatar avatar;
    public TextMesh name;
    // Start is called before the first frame update
    void Start() {
        avatar = transform.GetComponent<DynamicCharacterAvatar>();
        if(SystemVariables.player1.playerTypeIndex == 1) {
            avatar.ChangeRace("HumanMale");
        }
        else {
            avatar.ChangeRace("HumanFemale");
        }

        name.text = SystemVariables.player1.name;
    }

    // Update is called once per frame
    void Update() {
        
    }
}
