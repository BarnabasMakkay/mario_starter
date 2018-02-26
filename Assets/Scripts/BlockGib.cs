using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGib : MonoBehaviour
{

    public float forceValue = 0.0f;
    public float SecondsBeforeDestroy = 3.0f;

    public void Explode(Vector3 BlockCentre)
    {

        // get a reference to the rb
        Rigidbody rb = GetComponent<Rigidbody>();

        // setup and apply the force
        rb.isKinematic = false;

        // apply the force
        rb.AddExplosionForce(forceValue, BlockCentre, 2.0f);

        // Start a timer to destry blocks
        StartCoroutine("WaitAndDestroy");

    }

    // Wait and then destry the block
    IEnumerator WaitAndDestroy()
    {
        yield return new WaitForSeconds(SecondsBeforeDestroy);
        Destroy(gameObject);
    }

}
