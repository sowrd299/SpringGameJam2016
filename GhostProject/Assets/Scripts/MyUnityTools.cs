using System;
using UnityEngine;


static class MyUnityTools {

    /*
    some useful tools for unity I wrote
    feel free to use them
    */

    public static void dflt<T>(ref T obj, string name) {
        /*
        sets the default value for var obj as the component of class T on the Game Object named name
        default value is used when no value is given in the unity editor, not used when one it
        Usage:
            public type varName;
            void Start(){
            void Awake(){
                MyUnityTools.dflt(ref varName, "ObjectName");
            }
        */
        if (obj != null) return;
        GameObject go = GameObject.Find(name);
        if (go != null) obj = go.GetComponent<T>();
    }

}

