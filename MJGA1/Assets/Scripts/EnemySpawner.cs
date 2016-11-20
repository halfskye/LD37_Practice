using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float Timer;

    public Vector3 enemySpawn;
    float x;
    float y = 5;
    float z = 0;
    GameObject enemy;


	// Use this for initialization
	void Awake () {

    }
	

	void Update () {

                int spawnTimer = Random.Range(2, 50);

        if (spawnTimer == 3)
            {

                x = Random.Range(-6.5f, 7);

                enemy = (GameObject)Instantiate(Resources.Load("Enemy"));

                enemySpawn = new Vector3(x, y, z);

                enemy.transform.position = enemySpawn;
            }


        Destroy(enemy, 5);
            //}
        //}
	
	}
}
