using UnityEngine;
using System.Collections;
using System;

public class PlayerAbilities : MonoBehaviour {

    public Transform bulletOrigin;


	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject player = Player.Instance.getPlayer();
            GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"));
            bullet.transform.position = bulletOrigin.transform.position;

            Destroy(bullet, 1.2f);

        }
    }
}
