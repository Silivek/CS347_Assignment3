using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
///
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
	[Header("Set in Inspector")]

	public GameObject basketPrefab;
	public int numBaskets = 3;
	public float basketBottomY = -14f;
	public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    //////
    public bool isGameover;
    //////
    private float surviveTime;
    //////
    public GameObject gameoverText;

    public int bombsDropped = 0;

    // Start is called before the first frame update
    void Start()
    {
        

        basketList = new List<GameObject>();

        ////
        isGameover = false;
        ////
        surviveTime = 0;



        for (int i=0; i<numBaskets; i++){
        	GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);

        	Vector3 pos = Vector3.zero;
        	pos.y = basketBottomY + (basketSpacingY * i);
        	tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
    }

    public void AppleDestroyed() {
        GameObject[] tAppleArray=GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGO in tAppleArray) {
            Destroy(tGO);
        }

        if (!isGameover){
            int basketIndex = basketList.Count-1;
            GameObject tBasketGO = basketList[basketIndex];
            basketList.RemoveAt(basketIndex);
            Destroy(tBasketGO);
        }

        if (basketList.Count == 0) {

            EndGame();
        //    SceneManager.LoadScene("_Scene_0");
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover){
            surviveTime += Time.deltaTime;
           //timeText.text = "Time: "+(int)surviveTime;
            //print(surviveTime);

            if (surviveTime > 30){
                NextLevel();
            }
        }

        else
        {
            if(Input.GetKeyDown(KeyCode.R)){
                 gameoverText.SetActive(false);
                 SceneManager.LoadScene("_Scene_0");            
            }
        }

        
    }

    public void EndGame() {
        isGameover = true;
        gameoverText.SetActive(true);

    }


    public void NextLevel() {

        //SceneManager.LoadScene("_Scene_1");            


    }
}
