using UnityEngine;
using System.Collections;

public class GazeTransition : MonoBehaviour {

    Animator animator;


	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	void Update ()
    {
	    if (GetComponent<GazeAwareComponent>().HasGaze)
        {
            animator.SetBool("GazeAware", true);
        }
        else
        {
            animator.SetBool("GazeAware", false);
        }
	}
}
