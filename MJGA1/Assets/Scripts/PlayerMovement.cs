using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public Sprite sprt_straight;
    public Sprite sprt_left;
    public Sprite sprt_right;

    public float lrSpeed = 14f;
    public float udSpeed = 11f;

    private float lrSpeedBoost = 2;
    private float udSpeedBoost = 2;
    private const float lrSpeedMax = 40;
    private const float udSpeedMax = 35;
    private float lrSpeedMin = 14f;
    private float udSpeedMin = 11f;

    private SpriteRenderer sprtRend;

    void Start() {
        sprtRend = GetComponent<SpriteRenderer>();
        if (sprtRend.sprite == null)
        {
            sprtRend.sprite = sprt_straight;
        }
    }

	// Update is called once per frame
	void Update () {
	
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * lrSpeed);
            sprtRend.sprite = sprt_left;
        }
        else
        {
            sprtRend.sprite = sprt_straight;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * lrSpeed);
            sprtRend.sprite = sprt_right;
        }
        else
        {
            sprtRend.sprite = sprt_straight;
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * udSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * udSpeed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            lrSpeed += lrSpeedBoost;
            udSpeed += udSpeedBoost;

            if (lrSpeed >= lrSpeedMax)
            {
                lrSpeed = lrSpeedMax;
            }
            if (udSpeed >= udSpeedMax)
            {
                udSpeed = udSpeedMax;
            }

        }
        else
        {
            lrSpeed -= lrSpeedBoost;
            udSpeed -= udSpeedBoost;

            if (lrSpeed <= lrSpeedMin)
            {
                lrSpeed = lrSpeedMin;
            }
            if (udSpeed <= udSpeedMin)
            {
                udSpeed = udSpeedMin;
            }
        }

    }
}
