using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public GameObject bulletPrefab;

    public int bulletCount = 0;

    public int shotLimit;




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

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25, 25), -10, 0);


        if (Input.GetKeyDown(KeyCode.Space) && bulletCount < shotLimit) {
            Instantiate(bulletPrefab, transform.position + new Vector3(0,5,0), Quaternion.identity);
            bulletCount++;
        }

    }
    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Alien")
        {
            Destroy(collidedWith);
            //do magic player things here
        }
    }
}
