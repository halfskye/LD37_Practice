using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

    private float Timer;

    public Vector3 enemySpawn;
    float x;
    float y = 6;
    float z = 0;



    GameObject enemy;


	// Use this for initialization
	void Awake () {

    }
	

	void Update () {

        int spawnTimer = Random.Range(1, 70);

        if (spawnTimer == 3)
            {
                
                x = Random.Range(-8f, 7.5f);
                enemy = (GameObject)Instantiate(Resources.Load("Enemy"));
                                
                enemySpawn = new Vector3(x, y, z);
                
                enemy.transform.position = enemySpawn;
               
        }


        Destroy(enemy, 5);
            //}
        //}
	
	}
}
