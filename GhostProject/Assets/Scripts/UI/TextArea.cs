using UnityEngine;
//using UnityEngine.UI;

public class TextArea : MonoBehaviour {

	public Transform mainButtons;
	public Transform credits;

    void Start() {
        MyUnityTools.dflt(ref mainButtons, "MainButtons");
        MyUnityTools.dflt(ref credits, "Credits");
    }

	public void dispMainButtons(){
		mainButtons.gameObject.SetActive (true);
		credits.gameObject.SetActive (false);
	}

	public void dispCredits(){
		mainButtons.gameObject.SetActive (false);
		credits.gameObject.SetActive (true);
	}

}
