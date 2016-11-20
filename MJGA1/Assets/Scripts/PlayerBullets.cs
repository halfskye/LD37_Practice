using UnityEngine;
using System.Collections;

public class PlayerBullets : MonoBehaviour
{

    public float bulletSpeed = 15f;
    //private BoxCollider2D coll;



    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D Enemy)
    {
        //ContactPoint contact = collision.contacts[0];
        //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        //Vector3 pos = contact.point;
        //Instantiate(explosionPrefab, pos, rot);
        if (Enemy.gameObject.tag == "Enemy")
        {
            Debug.Log("hit enemy");
            Destroy(Enemy.gameObject);
            Destroy(this.gameObject);
        }
    }
}
