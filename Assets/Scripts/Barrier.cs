using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GameObject.Find("BarrierDestroy").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Bomb") {
            audio.Play();
            Destroy(col.gameObject);
            GameObject.Find("GameManager").GetComponent<GameManagerBehavior>().barrierCount--;
            Destroy(gameObject);
        }
    }
}
