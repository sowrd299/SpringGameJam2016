using UnityEngine;
using System.Collections.Generic;

public delegate bool Condition();

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
            void Awake(){
                MyUnityTools.dflt(ref varName, "ObjectName");
            }
        */
        if (obj != null) return;
        GameObject go = GameObject.Find(name);
        if (go != null) obj = go.GetComponent<T>();
    }

    public static T[] ToArray<T>(IEnumerable<T> enume) {
        /*
        usable outside untiy; consider porting to a more apropriate class
        converts the enumerable enume to an array
        */
        var r = new List<T>();
        foreach(T t in enume) {
            r.Add(t);
        }
        return r.ToArray();
    }

}

