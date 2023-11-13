using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreGT;
    public AudioClip death;
    private AudioSource playerAudio;
    private GameObject bombSoundPlayer;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO=GameObject.Find("ScoreCounter");
        scoreGT=scoreGO.GetComponent<Text>();
        scoreGT.text = "0";
        playerAudio = GetComponent<AudioSource>();

        bombSoundPlayer = GameObject.Find("ExplosionSound"); //GameObject which plays the explosion sound


    }

    // Update is called once per frame
    void Update()
    {
    	Vector3 mousePos2D = Input.mousePosition;
      	mousePos2D.z = -Camera.main.transform.position.z;
      	Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
      	Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;

        if (Input.GetKey(KeyCode.RightArrow) == true){
            pos.x = pos.x + 0.5f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) == true){
            pos.x = pos.x - 0.5f;
        }




        this.transform.position = pos;
        
    }

    void OnCollisionEnter(Collision coll){
    	GameObject collidedWith = coll.gameObject;
    	if (collidedWith.tag == "Apple") {
    		Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text =score.ToString();

            playerAudio.Play();

            if (score > HighScore.score) {
                HighScore.score = score;
            }

    	}

        if (collidedWith.tag == "Bomb") {
            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
            apScript.AppleDestroyed();


            bombSoundPlayer.GetComponent<AudioSource>().Play();

            Destroy(collidedWith); //Destroy the bomb

            //playerAudio.Play();  //Play bomb explosion sound
        }
    }
}
