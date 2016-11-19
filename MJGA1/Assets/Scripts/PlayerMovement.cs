using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    float lrSpeed = 6f;
    float udSpeed = 8f;

	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left / lrSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right / lrSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down / udSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up / udSpeed);
        }
    }
}
