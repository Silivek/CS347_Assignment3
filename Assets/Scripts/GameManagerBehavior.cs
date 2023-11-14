using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerBehavior : MonoBehaviour
{

    public GameObject alien1Prefab;
    public GameObject alien2Prefab;
    public GameObject barrierPrefab;

    public int barrierCount = 0;

    public int barrierMax = 27;

    public int aliensKilled = 0;

    public int killGoal;

    public int alienLimit;
    int alienCount = 0;

    public Text alienCountText; //Kill count
    public Text barrierCountText;

    public List<GameObject> barrierList;
    public float spawnInterval;

    float spawnTimer = 2;


    // Start is called before the first frame update
    void Start()
    {
        barrierList = new List<GameObject>();
        for (int i = 0; i < barrierMax; i++)
        {
            GameObject tempBarrier = Instantiate<GameObject>(barrierPrefab);
            tempBarrier.transform.position = new Vector3(-27 + (i * 2), -14, 0);
            tempBarrier.transform.rotation = Quaternion.Euler(90, 90, 0);
            barrierList.Add(tempBarrier);

            barrierCount++;
        }

        alienCountText.text = "?/30";
        barrierCountText.text = "?/?";
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0 && alienCount < alienLimit) {
            //Spawn enemy here
            int enemyType = Random.Range(0,2);
            int spawnSide = Random.Range(0,2);
            int spawnLane = Random.Range(0,3);


            switch (enemyType) {
                case 0:

                    Instantiate(alien1Prefab, new Vector3(-40 + (spawnSide * 70), 6 + (3 * spawnLane), 0), Quaternion.Euler(15, 90 + (180 * spawnSide), 0));

                    break;
                case 1:

                    Instantiate(alien2Prefab, new Vector3(-40 + (spawnSide * 70), 6 + (3 * spawnLane), 0), Quaternion.Euler(15, 90 + (180 * spawnSide), 0));

                
                    break;
            }

            alienCount++;

            spawnTimer = spawnInterval;

        } else spawnTimer -= Time.deltaTime;

        alienCountText.text = "Aliens:  " + aliensKilled + " / " + killGoal;
        barrierCountText.text = "Base Barrier:  " + barrierCount + " / " + barrierMax;



    }
}
