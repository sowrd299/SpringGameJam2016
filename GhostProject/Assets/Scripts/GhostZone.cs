using UnityEngine;

public class GhostZone : MonoBehaviour
{

    protected void Start()
    {
    }

    protected void Update()
    {
        if (GetComponent<GazeAwareComponent>().HasGaze)
        {
            GetComponent<Animator>().Play("front");
        }
        else
        {
            GetComponent<Animator>().Play("back");
        }
    }
}
