using UnityEngine;
using System.Collections;

public class UIButtonController : MonoBehaviour {

	public void LoadLevelTobii(int index)
    {
        GhostZone.tobii = true;
        LoadLevel(index);
    }

    public void LoadLevelMouse(int index)
    {
        GhostZone.tobii = false;
        LoadLevel(index);
    }

    public void LoadLevel(int index) {
        Application.LoadLevel(index);
    }
}
