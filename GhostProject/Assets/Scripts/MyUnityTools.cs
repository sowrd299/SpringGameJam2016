using System;
using UnityEngine;


static class MyUnityTools {

    /*
    some useful tools for unity I wrote
    feel free to use them
    */

    public static void dflt<T>(ref T obj, string name) {
        /*
        sets the default value for var obj as the component of class T of game object name
        */
        if (obj != null) return;
        GameObject go = GameObject.Find(name);
        if (go != null) obj = go.GetComponent<T>();
    }

}

