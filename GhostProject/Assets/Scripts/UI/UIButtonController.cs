using UnityEngine;
using System.Collections;

public class UIButtonController : MonoBehaviour {

    public Transform mainCanvas;
    public Transform instructionsCanvas;

	public void SelectTobii(int index)
    {
        GhostZone.tobii = true;
        dispInstructions();
    }

    public void SelectMouse(int index)
    {
        GhostZone.tobii = false;
        dispInstructions();
    }

    public void LoadLevel(int index) {
        Application.LoadLevel(index);
    }

    public void dispInstructions()
    {
        mainCanvas.gameObject.SetActive(false);
        instructionsCanvas.gameObject.SetActive(true);
    }
}
