using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehavior : MonoBehaviour
{

    public GameObject alien1Prefab;
    public GameObject alien2Prefab;
    public GameObject barrierPrefab;

    public List<GameObject> barrierList;
    public float spawnInterval;

    float spawnTimer = 2;


    // Start is called before the first frame update
    void Start()
    {
        barrierList = new List<GameObject>();
        for (int i = 0; i < 27; i++)
        {
            GameObject tempBarrier = Instantiate<GameObject>(barrierPrefab);
            tempBarrier.transform.position = new Vector3(-27 + (i * 2), -14, 0);
            tempBarrier.transform.rotation = Quaternion.Euler(90, 90, 0);
            barrierList.Add(tempBarrier);
        }
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

                    Instantiate(alien1Prefab, new Vector3(-30+(spawnSide*60), 6+(3*spawnLane), 0), Quaternion.Euler(30, 180, 0));

                    break;
                case 1:

                    Instantiate(alien2Prefab, new Vector3(-30+(spawnSide*60), 6+(3*spawnLane), 0), Quaternion.Euler(15, 180, 0));

                
                    break;
            }

            spawnTimer = 2;

        } else spawnTimer -= Time.deltaTime;
    }
}
