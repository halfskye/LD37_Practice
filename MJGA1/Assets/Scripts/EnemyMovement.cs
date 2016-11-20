using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    public float moveSpeed = 1;
    public int rotateSpeed;
    private int x = 0;
    private int y = 0;

	// Use this for initialization
	void Start () {

        //Rotate Speed Initialization
        rotateSpeed = Random.Range(-7, 7);
        if (rotateSpeed == 0)
        {
            rotateSpeed = 1;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
            //Rotation
            transform.Rotate(0f, 0f, rotateSpeed);
            
            //Movement
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * moveSpeed);
        
    }
}
