using UnityEngine;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour {

    /*
    central game logic
    */

    //images
    public Sprite policeSprt;
    public Sprite magicSprt;
    public Sprite construcSprt;
    public Sprite armySprt;
    public Sprite chefSprt;
    public Sprite cowSprt;

    public int startingGhosts; //number of ghosts to start with
    public GameObject ghostPrefab; //public for unity; do not access
    public GameObject daemonGhostPrefab; //public for...blah...blah...blah...

    public TopBar hud;
    public PointsPopup pointsPopup;

    //SCORE
    private int score = 0;

    //TIMER
    private const float baseTimeToFind = 10.0f; //the base time aloted to find each ghost
    private float timeLeft;

    //TYPES
    private const int baseNumTypes = 6; //the ulitmate number of types of ghosts
    public int NumTypes {
        //the number currenlty in play
        //increases with level
        get { return baseNumTypes - 2 + score/25; }
    }
    public static readonly Color[] typeColors = new Color[baseNumTypes] {
             new Color(49/255f,246/255f,255/255f), //cyan
             new Color(255/255f,11/255f,188/255f), //magenta
             new Color(248/255f,255/255f,49/255f), //yellow
             new Color(11/255f,255/255f,78/255f), //mint
             new Color(89/255f,49/255f,246/255f), //purple
             new Color(255/255f,162/255f,56/255f) //peach
    };
    public static Sprite[] typeIcons;
    private int targetType; //stores the target type as int
    public int TargetType {
        get { return targetType; }
    }

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
        GameObject g;
        //chance of creating a deamon ghost slowly increases with time
        int chance = 9 + score / 5;
        if (chance > 20) chance = 20;
        if (UnityEngine.Random.Range(0,9+score/5) > 10) {
            g = Instantiate(daemonGhostPrefab);
        } else {
            g = Instantiate(ghostPrefab);
        }
        g.GetComponent<Ghost>().init(UnityEngine.Random.Range(0,NumTypes),LevelMin,LevelMax,this);
    }

    int[] presentTypes() {
        /*
        returns a list of all types present in the current ghosts
        */
        var typesFound = new HashSet<int>();
        GameObject[] ghosts = GameObject.FindGameObjectsWithTag("Ghost");
        foreach(GameObject ghost in ghosts) {
            Debug.Log(ghost);
            typesFound.Add(ghost.GetComponent<Ghost>().Type);
        }
        Debug.Log("Found " + typesFound.Count + " types.");
        return MyUnityTools.ToArray(typesFound);
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
        //because gamejam;
        typeIcons = new Sprite[baseNumTypes] {
                policeSprt,//Resources.Load<Sprite>("Sprites/ghost_police_hat"), //cyan
                magicSprt,
                construcSprt,
                armySprt,
                chefSprt,
                cowSprt
        };
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
        //reset the time
        timeLeft = baseTimeToFind - score / 15; //time encroaches downward as time progress
        if (timeLeft < 4f) timeLeft = 4f; //mimimum time; improve implementation 
        //generate a new randome target type that is not the same one
        int targetType;
        int[] legalTypes = presentTypes();
        if (legalTypes.Length == 1) {
            targetType = legalTypes[0];
        } else {
            do {
                targetType = legalTypes[UnityEngine.Random.Range(0, legalTypes.Length)];
            } while (targetType == this.targetType);
        }
        //apply that type 
        Debug.Log("Target type is: "+targetType.ToString());
        this.targetType = targetType;
        dispType(targetType);
    }
    
    private void dispType(int t) {
        //display type-relevent information to the hud
        Debug.Log("Displaying type " + t.ToString());
        hud.setColor(typeColors[t]);
        try {
            hud.setTypeIcon(typeIcons[t]);
        } catch (NullReferenceException) {}
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
