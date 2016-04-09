using UnityEngine;

public class LevelManager : MonoBehaviour {

    /*
    central game logic
    */

    public int startingGhosts; //number of ghosts to start with
    public GameObject ghostPrefab; //public for unity; do not access

    private TopBar hud;

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
            {new Color(248,255,49), //mint
             new Color(49,246,255), //cyan
             new Color(255,11,188), //magenta
             new Color(11,255,78), //yellow
             new Color(89,49,246), //purple
             new Color(255,162,56) }; //peach
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
        g.GetComponent<Ghost>().init(Random.Range(0,NumTypes),LevelMin,LevelMax);
    }

    public void selectGhost(Ghost g) { //to be called by the ghosts themselves
        //Check what type of ghost, if it is the correct type send it to work and add points, if it is incorrect deduct points
        if(g.Type == targetType) {
            scorePoints(g.PointsValue);
            reset();
            spawnGhosts(2);
        } else {
            //maybe loose points?
        }
        //g.destroy();
    }

	// Use this for initialization
	void Start () {
        spawnGhosts(startingGhosts);
        MyUnityTools.dflt(ref hud, "TopBar");
        reset();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        hud.setTimer((int)timeLeft,true);
        if (timeLeft < 0) {
            GameOver();
        }
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
        this.targetType = targetType;
        dispType(targetType);
    }
    
    private void dispType(int t) {
        //display type-relevent information to the hud
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
