﻿using UnityEngine;

public class GhostZone : MonoBehaviour
{

    public LevelManager lm;
    public static bool tobii = false;
    bool mouse = false;

    public bool fading = false;

    protected void Awake()
    {
        MyUnityTools.dflt(ref lm, "LevelController");
    }

    protected void Update()
    {
        if (tobii && GetComponent<GazeAwareComponent>().HasGaze || mouse)
        {
            GetComponent<Animator>().Play("front");
            Debug.Log("Interacting with a ghost!");
            //GetComponent<Animator>().Play(GetComponent<Ghost>().Type.ToString());

            if (Input.GetKeyDown(KeyCode.Space)) {
                GetComponent<Ghost>().select();
            }
        }
        else
        {
            GetComponent<Animator>().Play("back");
        }

        if (fading) { lerpAlpha();  }
    }

    void OnMouseEnter()
    {
        if (!tobii)
        {
            mouse = true;
        }
    }

    void OnMouseExit()
    {
        if (!tobii)
        {
            mouse = false;
        }
    }

    void lerpAlpha()
    {
        Color temp = this.gameObject.GetComponent<Renderer>().material.color;
        temp.a = temp.a / 1.1f;
        this.gameObject.GetComponent<Renderer>().material.color = temp;
    }
}
