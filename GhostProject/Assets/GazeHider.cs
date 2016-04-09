using UnityEngine;
using System.Collections;
using Tobii.EyeX.Framework;

public class GazeHider : MonoBehaviour {

    /*
    hides the attached game object whenever the target game object is not being looked at
    */

    private EyeXHost host;
    public GazeAwareComponent trigger;

    void Start() {
        host = EyeXHost.GetInstance();
    }

	void Update () {
        gameObject.SetActive(host.EyeTrackingDeviceStatus != EyeXDeviceStatus.Tracking || trigger.HasGaze);
	}
}
