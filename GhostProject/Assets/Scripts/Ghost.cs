using UnityEngine;
using System;

public class Ghost : MonoBehaviour {

    /*
    manages gameplaty elements of ghosts
    */

    public LevelManager lm;
    protected const int defPointsValue = 5; //default points value

    private int type;
    public int Type {
        get { return type;  }
        set {
            if(value < lm.NumTypes) {
                type = value;
            } else {
                //if the type does not exist, raise an exception
                throw new ArgumentOutOfRangeException("Type expects value < LevelManage.NumTypes");
            }
        }
    }

    private int pointsValue = defPointsValue;
    public int PointsValue {
        get { return pointsValue;  }
    }

    public void init(int t, Vector2 pMi, Vector2 pMa, LevelManager lm) {
        init(t, pMi, pMa);
        this.lm = lm;
    }

    public void init(int t, Vector2 pos) {
        init(t, pos, pos);
    }

    public void init(int type, Vector2 minPos, Vector2 maxPos) {
        MyUnityTools.dflt(ref lm, "LevelController");
        //pseudo-constructor
        //initialize a newly spawned ghost from script
        Type = type;
        transform.position = new Vector2(UnityEngine.Random.Range(minPos.x,maxPos.x),
                                         UnityEngine.Random.Range(minPos.y,maxPos.y));
    }

    public void select() {
        /*
        what happens when the ghost gets booped
        */
        if (lm.selectGhost(this))
        {
            gameObject.GetComponent<GhostZone>().fading = true;
            Invoke("destroy", 1);
        }
    }

    public void destroy() {
        //destroy the game object
        Destroy(gameObject);
    }

}
