using UnityEngine;

public class LevelManager : MonoBehaviour {

    /*
    central game logic
    */

    public int startingGhosts; //number of ghosts to start with
    public GameObject ghostPrefab; //public for unity; do not access

    public TopBar hud;
    public PointsPopup pointsPopup;

    //SCORE
    private int score = 0;

    //TIMER
    private const float baseTimeToFind = 10.0f; //the base time aloted to find each ghost
    private float timeLeft;

    //TYPES
    private const int baseNumTypes = 6; //the number of types of ghosts
    public int NumTypes {
        //increases with level
        get { return baseNumTypes - 2 + score/25; }
    }
    public static readonly Color[] typeColors = new Color[baseNumTypes]
            {new Color(248/255f,255/255f,49/255f), //mint
             new Color(49/255f,246/255f,255/255f), //cyan
             new Color(255/255f,11/255f,188/255f), //magenta
             new Color(11/255f,255/255f,78/255f), //yellow
             new Color(89/255f,49/255f,246/255f), //purple
             new Color(255/255f,162/255f,56/255f) }; //peach
    private int targetType; //stores the target type as int

    //LEVEL BOUNDS
    public Vector2 LevelMin {
        get { return ((Vector2)Camera.main.transform.position - new Vector2(Screen.width/2, Screen.height/2))/100; }
    }
    public Vector2 LevelMax {
        get { return LevelMin + new Vector2(Screen.width, Screen.height)/100; }
    }

    void spawnGhosts(int num) {
        /*
        populate the screen with num ghosts
        */
        for(int i = 0; i < num; i++) {
            spawnGhost();
        }
    }

    void spawnGhost() {
        /*
        spawn an individual ghost
        */
        GameObject g = Instantiate(ghostPrefab);
        g.GetComponent<Ghost>().init(Random.Range(0,NumTypes),LevelMin,LevelMax,this);
    }


    public bool selectGhost(Ghost g) { //to be called by the ghosts themselves
        //Check what type of ghost, if it is the correct type send it to work and add points, if it is incorrect deduct points
        if(g.Type == targetType) {
            scorePoints(g.PointsValue);
            pointsPopup.score(g.PointsValue, Camera.main.WorldToScreenPoint(g.transform.position), hud.timerText.color);
            reset();
            spawnGhosts(2);
            return true;
        } else {
            //maybe loose points?
            return false;
        }
        //g.destroy();
    }

	// Use this for initialization
	void Start () {
        Debug.Log("Het is wel aan het starten!");
        spawnGhosts(startingGhosts);
        MyUnityTools.dflt(ref hud, "TopBar");
        reset();
        Debug.Log("Het is nog steds aan het starten!");
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        hud.setTimer((int)timeLeft,true);
        if (timeLeft < 0) {
            GameOver();
        }
        //and not, for the world's jankiest fix:
        //if it seems too fade too fast on you computer, comment it out
        hud.splash.Update();
	}

    void scorePoints(int points) {
        score += points;
        hud.setScore(score);
    }

    void reset() {
        /*
        resets for a new round
        */
        timeLeft = baseTimeToFind - score/3; //time encroaches downward as time progress
        if (timeLeft < 4f) timeLeft = 4f; //mimimum time; improve implementation 
        //generate a new random target type that is not the same one
        int targetType;
        do {
            targetType = Random.Range(0, NumTypes);
        } while (targetType == this.targetType);
        Debug.Log("Target type is: "+targetType.ToString());
        this.targetType = targetType;
        dispType(targetType);
    }
    
    private void dispType(int t) {
        //display type-relevent information to the hud
        Debug.Log("Displaying type " + t.ToString());
        hud.setColor(typeColors[t]);
        //hud.setTypeIcon(typeIcons[t]);
    }

    void GameOver() {
        //self-destructive; normal functioning not intended to be resumed
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Ghost")) {
            //massacre ghosts
            go.GetComponent<Ghost>().destroy();
        }
        hud.endGame(score);
        gameObject.SetActive(false);
    }


}
