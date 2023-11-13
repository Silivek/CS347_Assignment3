using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{

    public GameObject alien1Prefab;
    public GameObject alien2Prefab; 

    public float spawnInterval;

    float spawnTimer = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0) {
            //Spawn enemy here
            int enemyType = Random.Range(0,2);
            int spawnSide = Random.Range(0,2);
            int spawnLane = Random.Range(0,3);


            switch (enemyType) {
                case 0: 

                    Instantiate(alien1Prefab, new Vector3(-30+(spawnSide*60), 6+(3*spawnLane), 0), Quaternion.identity);

                    break;
                case 1:

                    Instantiate(alien2Prefab, new Vector3(-30+(spawnSide*60), 6+(3*spawnLane), 0), Quaternion.identity);

                
                    break;
            }

            spawnTimer = 1;

        } else spawnTimer -= Time.deltaTime;
    }
}
