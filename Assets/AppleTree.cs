using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    
	public GameObject applePrefab;
    public GameObject bombPrefab;
	public float speed=1f;
	public float leftAndRightEdge =20f;
	public float chanceToChangeDirections = 0.02f;
	public float secondBetweenAppleDrops = 1f;
    public static float bottomY = -20f;


    // Start is called before the first frame update
    void Start()
    {
        //if  game starts, start dropping apples
        Invoke ("DropApple", 2f);
    }


    void DropApple() {

        GameObject apple;

        if (Random.value >= 0.8) { //Randomly choose to drop a bomb instead

            apple = Instantiate<GameObject>(bombPrefab);

        } else {

            apple = Instantiate<GameObject>(applePrefab);

        }


        apple.transform.position = transform.position;
        Invoke("DropApple", secondBetweenAppleDrops);

    }
    // Update is called once per frame
    void Update()
    {

       
        //basic movement of appletree

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge){
            speed = -Mathf.Abs(speed);

        } 
        
    }

    void FixedUpdate() {
        
        if (Random.value <chanceToChangeDirections) {
            speed *= -1;
        }

    }
}
