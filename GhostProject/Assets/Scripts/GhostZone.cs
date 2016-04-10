using UnityEngine;

public class GhostZone : MonoBehaviour
{

    public LevelManager lm;
    public static bool tobii = true;
    bool mouse = false;

    protected void Awake()
    {
        MyUnityTools.dflt(ref lm, "LevelController");
    }

    protected void Update()
    {
        if (tobii && GetComponent<GazeAwareComponent>().HasGaze || mouse)
        {
            Debug.Log("Interacting with a ghost!");
            playFront();
        }
        else
        {
            playBack();
        }
    }

    protected virtual void playFront() {
        GetComponent<Animator>().Play(GetComponent<Ghost>().Type.ToString());
        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Ghost>().select();
        }
    }

    protected virtual void playBack() {
        GetComponent<Animator>().Play("back");
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
}
