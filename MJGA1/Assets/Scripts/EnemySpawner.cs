using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float Timer;

    public Vector3 enemySpawn;
    public Vector3 enemyDiagRightSpawn;
    public Vector3 enemyDiagLeftSpawn;
    float x;
    float y;
    float z = 0;



    GameObject enemy;
    GameObject enemyDiagRight;
    GameObject enemyDiagLeft;


	// Use this for initialization
	void Awake () {

    }
	

	void Update () {

        int spawnTimer = Random.Range(1, 700);

        //int spawnTimer = 1;

        if (spawnTimer == 4 || spawnTimer == 5 || spawnTimer == 6 || spawnTimer == 7)
            {
                
                x = Random.Range(-8f, 7.5f);
                y = 6;
                enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
                                
                enemySpawn = new Vector3(x, y, z);
                
                enemy.transform.position = enemySpawn;
        }

        if (spawnTimer == 1)
        {
            x = Random.Range (11, 14);
            y = -7;

            enemyDiagRight = (GameObject)Instantiate(Resources.Load("DiagAsteroidRight"));
            enemyDiagRightSpawn = new Vector3(x, y, z);

            enemyDiagRight.transform.position = enemyDiagRightSpawn;

        }

        if (spawnTimer == 2)
        {
            x = Random.Range(-13, -10);
            y = -7;

            enemyDiagLeft = (GameObject)Instantiate(Resources.Load("DiagAsteroidLeft"));
            enemyDiagLeftSpawn = new Vector3(x, y, z);

            enemyDiagLeft.transform.position = enemyDiagLeftSpawn;

        }


        Destroy(enemy, 5);
            //}
        //}
	
	}
}
