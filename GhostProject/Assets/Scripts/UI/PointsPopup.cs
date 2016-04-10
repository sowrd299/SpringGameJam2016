using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PointsPopup : MonoBehaviour {

    public Text pointsText;

    public void score(int points, Vector3 location, Color color)
    {
        //Debug.Log("MOVING POPUP TO LOCATION " + location.ToString());
        pointsText.text = points.ToString();
        pointsText.transform.position = location;
        pointsText.color = color;
        gameObject.SetActive(true);
        Invoke("setInactive", 0.5f);
        pointsText.fontSize = 20;
        //Debug.Log("POPUP IS NOW AT LOCATION " + location.ToString());
    }

    void setInactive()
    {
        gameObject.SetActive(false);
    }


	// Use this for initialization
	void Start () {
        pointsText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        pointsText.fontSize += 1;
	}
}
