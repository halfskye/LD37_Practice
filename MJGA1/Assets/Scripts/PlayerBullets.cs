using UnityEngine;
using System.Collections;

public class PlayerBullets : MonoBehaviour {

    public float bulletSpeed = 15f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);

	}
}
