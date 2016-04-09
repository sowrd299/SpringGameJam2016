using UnityEngine;
using System.Collections;
using System;

public class LevelManager : MonoBehaviour {

    int score = 0;
    float timeLeft = 30.0f;

    void spawnGhosts() {

    }

    void selectGhost()
    {
        //Check what type of ghost, if it is the correct type send it to work and add points, if it is incorrect deduct points
    }

	// Use this for initialization
	void Start () {
        spawnGhosts();
	}
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown("space"))
        {
            //Get Tobii cursor position, check if it is over a ghost, if it is use selectGhost() on that ghost
        }
	}

    void GameOver()
    {

    }
}
