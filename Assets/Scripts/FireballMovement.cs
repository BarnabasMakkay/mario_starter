using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    public float lifeTime;
    public Vector3 velocity;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //velocity = rb.velocity;
        rb.velocity = velocity;
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.y < velocity.y)
        {
            rb.velocity = velocity;
        }
        
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        // if colliding with enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // kill enemy
            Destroy(collision.gameObject);
            Debug.Log("killed enemy?");
        }
        else if (collision.gameObject.CompareTag("Pipe"))
        {
            Destroy(gameObject);
        }
        else
        {
            rb.velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
    }
}
