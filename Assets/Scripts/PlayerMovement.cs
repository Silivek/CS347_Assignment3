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

    float stunTimer = 0;

    public float stunDuration;




    // Start is called before the first frame update
    void Start()
    {
        rb  = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stunTimer <= 0) {
            int hsp = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
                hsp = -1;

            if (Input.GetKey(KeyCode.RightArrow))
                hsp = 1;

            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
                hsp = 0;

            rb.velocity = new Vector3(hsp*moveSpeed, 0, 0);

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -25, 25), -10, 0);


            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && bulletCount < shotLimit) {
                Instantiate(bulletPrefab, transform.position + new Vector3(0,5,0), Quaternion.identity);
                bulletCount++;
            }

        } else stunTimer -= Time.deltaTime;

    }
    void OnTriggerEnter(Collider coll)
    {
        GameObject collidedWith = coll.gameObject;
        if (collidedWith.tag == "Bomb")
        {
            Destroy(collidedWith);
            if(stunTimer <= 0)
            {
                stunTimer = stunDuration;
                rb.velocity = new Vector3(0, 0, 0);
            }
        }
    }
}
