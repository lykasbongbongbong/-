using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SystemVariables {
    public static PlayerInfo player1 = new PlayerInfo();
    public static PlayerInfo player2 = new PlayerInfo();
    public static Difficulty difficulty = Difficulty.Easy;
}

public class PlayerInfo {
    public string name;
    public int playerTypeIndex;
}

public enum Difficulty {
    Easy, Normal
}

public static class Init {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        Screen.fullScreen = false;
    }
}
