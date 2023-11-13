using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public GameObject bulletPrefab;




    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int hsp = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
            hsp = -1;

        if (Input.GetKey(KeyCode.RightArrow))
            hsp = 1;

        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            hsp = 0;

        rb.velocity = new Vector3(hsp*moveSpeed, 0, 0);


        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(bulletPrefab, transform.position + new Vector3(0,5,0), Quaternion.identity);
        }

    }
}
