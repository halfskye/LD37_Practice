using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

    private float moveSpeed = 1.75f;
    public int rotateSpeed;
    private int x = 0;
    private int y = 0;

    public enum Type
    {
        FALLING_ASTEROID = 0,
        RIGHT_ASTEROID = 1,
        LEFT_ASTEROID = 2,
    };

    [SerializeField]
    private Type type;

    void Start () {

        //Rotate Speed Initialization
        rotateSpeed = Random.Range(-7, 7);
        if (rotateSpeed == 0)
        {
            rotateSpeed = 1;
        }
    }
	
	void Update () {
        
            //Rotation
            transform.Rotate(0f, 0f, rotateSpeed);

        if (type == Type.FALLING_ASTEROID)
        {
            //Movement
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * moveSpeed);
        }

        if (type == Type.RIGHT_ASTEROID)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveSpeed + Vector2.left * moveSpeed);
        }
        if (type == Type.LEFT_ASTEROID)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * moveSpeed + Vector2.right * moveSpeed);
        }
    }
}
