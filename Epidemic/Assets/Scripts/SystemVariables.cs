using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SystemVariables {
    public static string id;
    public static List<string> usernames = new List<string>();
}

public static class Init {
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad() {
        Screen.fullScreen = false;
    }
}
