using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour {

    public float lifeTime;
    public float velocityX;
    public float velocityY;

    Rigidbody rb;
    Vector3 velocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(velocityX, velocityY, 0);

    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.y < velocityY)
        {
            rb.velocity.Set(velocityX, velocityY, 0);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = new Vector3(velocityX, -velocityY, 0);
    }
}
