using UnityEngine;
using UnityEngine.UI;

public class TopBar : MonoBehaviour {

    public Color startColor; //testing
    private Graphic[] elements;
    //public for unity; do not access
    public Text scoreText;
    public Text timerText;
    public Image typeIcon; 
    public Splash splash;
    public Transform gameOver;
    public Text goScoreText; //GameOver...

    void Awake() {
        Debug.Log("Het is wel aan het starten!");
        //initialize the elements array
        elements = GetComponentsInChildren<Graphic>();
        //initize special elemets; its repeat code I know, its a gamejam get off my back
        MyUnityTools.dflt(ref scoreText, "ScoreText");
        MyUnityTools.dflt(ref typeIcon, "TypeIcon");
        MyUnityTools.dflt(ref timerText, "TimerText");
        MyUnityTools.dflt(ref splash, "Splash");
        MyUnityTools.dflt(ref gameOver, "GameOver");
        MyUnityTools.dflt(ref goScoreText, "GO_ScoreText");
    }

    public void setColor(Color c) {
        /*
        sets the color of all top-bar gui elements
        */
        Debug.Log("Changing color for " + elements.Length + " elements.");
        foreach(Graphic g in elements) {
            g.color = c;
        }
    }

    public void setTypeIcon(Sprite s, bool splash = false) {
        /*
        sets the type icon to be displayed
        if splash, also splashes to screen
        */
        typeIcon.sprite = s;
        if (splash) {
            this.splash.splash(s, typeIcon.color);
        }
    }

    public void setTimer(int t, bool splash = false) {
        /*
        sets the time displayed
        if splash, also splashes to screen
        */
        string text = t.ToString() + "s";
        if (timerText.text == text) return;
        timerText.text = text;
        if(t <= 3 && splash ) {
            this.splash.splash(t.ToString(),timerText.color);
        }
    }

    public void setScore(int s) {
        /*
        sets the value displayed in the score area
        */
        string str = s.ToString();
        if(str.Length < 3) {
            //add leading 0's
            str = str.PadLeft(3, '0');
        }
        scoreText.text = str;
    }

    public void endGame(int score) {
        //note: is self-destructive. normal functionality not intended to be resumed.
        gameObject.SetActive(false);
        splash.gameObject.SetActive(false);
        scoreText = goScoreText;
        setScore(score);
        gameOver.gameObject.SetActive(true);
    }

}
