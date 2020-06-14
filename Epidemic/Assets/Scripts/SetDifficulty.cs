using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetDifficulty : MonoBehaviour {

    private int difficultyInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DifficultyChange(int i) {
        difficultyInput = i;
    }

    public void ConfirmDifficulty() {
        if(difficultyInput == 0) {
            SystemVariables.difficulty = Difficulty.Easy;
        }
        else {
            SystemVariables.difficulty = Difficulty.Normal;
        }
    }
}
