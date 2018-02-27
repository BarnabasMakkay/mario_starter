using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBlock : Block
{


	// Event for adding score
	public delegate void AddScore(int score);
	public static event AddScore addscore;

    Transform[] cubes;

	public GameObject WeaponToCollect;
	private bool weaponDeployed = false;
	public int scoreForDestroying = 100;
	public float moveHeight;

	// Use this for initialization
	void Awake ()
    {
        
        // Get access to all the components
        cubes = GetComponentsInChildren<Transform>();

	}

	public override void PlayerReaction()
	{


		// destroy the block
		if (weaponDeployed)
		{
			// unparent each of the cubes and destoy
			foreach (var t in cubes)
			{

				t.SetParent(null);

				BlockGib Gib = t.GetComponent<BlockGib>();

				if (Gib)
					Gib.Explode(transform.position);
			}

			// Add score here
			if (addscore != null)
				addscore(scoreForDestroying);

			//Destroy
			Destroy(gameObject);
		}
		else
		{
			if(!weaponDeployed)
				StartCoroutine("Animate");
		}

	}

	// Wait and then destry the block
	IEnumerator Animate()
	{


		// flag the state
		weaponDeployed = true;

		// get a start 
		Vector3 start = transform.position;

		// amimate the step
		for (int step = 0; step < 15; step++)
		{

			transform.position = new Vector3(start.x, start.y + moveHeight * Mathf.Sin((step / 15.0f) * Mathf.PI), start.y);
			yield return new WaitForEndOfFrame();
		}

		transform.position = start;

		// Spawn a coin
		var weapon = Instantiate(WeaponToCollect);
		weapon.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);

	}


}
