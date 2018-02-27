using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBlock : MonoBehaviour
{

    // Event for adding score
    public delegate void AddScore(int score);
    public static event AddScore addscore;

    Transform[] cubes;

    public int scoreForDestroying = 100;

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
        addscore(scoreForDestroying);

        //Destroy
        Destroy(gameObject);

    }


}
