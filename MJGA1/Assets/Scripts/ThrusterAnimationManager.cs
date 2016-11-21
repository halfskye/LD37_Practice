using UnityEngine;
using System.Collections;

public class ThrusterAnimationManager : MonoBehaviour {

    private Animator animator;
    //private InputState inputstate;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        //inputstate = GetComponent<InputState>();
	}
	
	// Update is called once per frame
	void Update () {

        //var speedBoost = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //speedBoost = true;

            animator.SetBool("SpeedBoost", true);
        }
        else
        {
            animator.SetBool("SpeedBoost", false);
        }

    }
}
