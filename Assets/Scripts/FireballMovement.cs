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
        }
        else if (collision.gameObject.CompareTag("Pipe"))
        {
            // collided into pipe
            Destroy(gameObject);
        }
        else
        {
            // bounce from floor and other objects
            rb.velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
    }

    public void SetXVelocityPositive()
    {
        velocity = new Vector3(Mathf.Abs(velocity.x), velocity.y, velocity.z);
        GetComponent<Rigidbody>().velocity = velocity;
    }

    public void SetXVelocityNegative()
    {
        velocity = new Vector3(-Mathf.Abs(velocity.x), velocity.y, velocity.z);
        GetComponent<Rigidbody>().velocity = velocity;
    }
}
