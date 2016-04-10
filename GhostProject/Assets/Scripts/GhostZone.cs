using UnityEngine;

[RequireComponent (typeof (GazeAwareComponent))]
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
            //GetComponent<Animator>().Play("front");
            Debug.Log("Interacting with a ghost of type " + GetComponent<Ghost>().Type);
            //GetComponent<Animator>().Play(GetComponent<Ghost>().Type.ToString());

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
                GetComponent<Ghost>().select();
            }
            playFront();
        }
        else
        {
            playBack();
        }

        if (fading) { lerpAlpha();  }
    }

    protected virtual void playFront() {
        GetComponent<Animator>().Play(GetComponent<Ghost>().Type.ToString());
        /*if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Ghost>().select();
        }*/
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

    void lerpAlpha()
    {
        Color temp = this.gameObject.GetComponent<Renderer>().material.color;
        temp.a = temp.a / 1.1f;
        this.gameObject.GetComponent<Renderer>().material.color = temp;
    }
}
