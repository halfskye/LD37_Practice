using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed = 1;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().AddForce(Vector2.down * moveSpeed);
    }
}
