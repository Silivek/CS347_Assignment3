using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public float moveSpeed = 3;
    public float bombFrequency;
    float bombTimer;
    public GameObject bombPrefab;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        bombTimer = bombFrequency;
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-moveSpeed,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 30) 
            rb.velocity = new Vector3(-moveSpeed,0,0);

        if (transform.position.x <= -30) 
            rb.velocity = new Vector3(moveSpeed,0,0);

        if (bombTimer <= 0)
        {
            Instantiate(bombPrefab, gameObject.transform.position, Quaternion.Euler(30, 180, 0));
            bombTimer = bombFrequency;
        }
        else bombTimer -= Time.deltaTime;
    }
}
