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
    private bool isLeft;
    private bool isRight;

    private SpriteRenderer sprtRend;

    void Start()
    {
        sprtRend = GetComponent<SpriteRenderer>();
        if (sprtRend.sprite == null)
        {
            sprtRend.sprite = sprt_straight;
        }
    }

    // Update is called once per frame
    void Update () {

        Physics2D.IgnoreLayerCollision(8,9);    

        #region BasicMovement
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * lrSpeed);
            //transform.Translate(Vector2.left / 6);
            isLeft = true;
        }
        else
        {
            isLeft = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * lrSpeed);
            //transform.Translate(Vector2.right / 6);
            isRight = true;
        }
        else
        {
            isRight = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.down * udSpeed);
            //transform.Translate(Vector2.down / 8);
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * udSpeed);
            //transform.Translate(Vector2.up / 8);
        }
        #endregion

        #region SpeedBoost
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
        #endregion

        #region SpriteAnimations
        if (isRight)
        {
            sprtRend.sprite = sprt_right;
        }

        if (isLeft)
        {
            sprtRend.sprite = sprt_left;
        }

        if (isLeft == false && isRight == false)
        {
            sprtRend.sprite = sprt_straight;
        }
        #endregion
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
    }
}
