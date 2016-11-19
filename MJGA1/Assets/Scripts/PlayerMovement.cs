using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float lrSpeed = 6f;
    public float udSpeed = 8f;

	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * lrSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * lrSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * udSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * udSpeed);
        }
    }
}
