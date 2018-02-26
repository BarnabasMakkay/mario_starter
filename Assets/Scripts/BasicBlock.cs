using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour
{

    Transform[] cubes;

	// Use this for initialization
	void Awake ()
    {
        
        // Get access to all the components
        cubes = GetComponentsInChildren<Transform>();

	}

    public void PlayerReaction()
    {

        // unparent each of the cubes
        foreach(var t in cubes)
        {

            t.SetParent(null);

            BlockGib Gib = t.GetComponent<BlockGib>();

            if (Gib)
                Gib.Explode(transform.position);
        }

        // Add score here

        //Destroy
        Destroy(gameObject);

    }


}
