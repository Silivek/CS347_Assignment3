using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{

    public static float bottomY = -20f;
    // Start is called before the first frame update
    void Start()
    {

        ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
        apScript.bombsDropped++;    //Increment Bomb counter

        GameObject bombCountGO=GameObject.Find("BombCount");
        Text gt = bombCountGO.GetComponent<Text>();
    	gt.text = "Bomb Count: "+apScript.bombsDropped.ToString();    //Update text
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < bottomY) {
            Destroy(this.gameObject);
         }
    }
}
