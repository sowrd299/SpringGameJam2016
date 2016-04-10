using UnityEngine;
using System.Collections;

public class UIButtonController : MonoBehaviour {

	public void LoadLevelTobii(int index)
    {
        GhostZone.tobii = true;
        Application.LoadLevel(index);
    }

    public void LoadLevelMouse(int index)
    {
        GhostZone.tobii = false;
        Application.LoadLevel(index);
    }
}
