using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left / 6);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right / 6);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.down / 8);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up / 8);
        }
    }
}
