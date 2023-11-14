using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaser : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(0, moveSpeed, 0);

        if (transform.position.y > 20) {
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider col) {
        if (col.tag == "Bomb") {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        GameObject go = GameObject.Find("PlayerShip");
        go.GetComponent<PlayerMovement>().bulletCount--;
    }
}
