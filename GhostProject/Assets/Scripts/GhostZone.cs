using UnityEngine;

public class GhostZone : MonoBehaviour
{
    public static bool tobii = false;
    bool mouse = false;

    protected void Start()
    {
    }

    protected void Update()
    {
        if (tobii && GetComponent<GazeAwareComponent>().HasGaze || mouse)
        {
            GetComponent<Animator>().Play("front");
        }
        else
        {
            GetComponent<Animator>().Play("back");
        }
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
