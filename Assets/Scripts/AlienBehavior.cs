using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehavior : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 30) 
            rb.velocity = new Vector3(-moveSpeed,0,0);

        if (transform.position.x <= -30) 
            rb.velocity = new Vector3(-moveSpeed,0,0);
    }
}
