using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // variables for initialisation 
    private Transform player_ref;


	// Use this for initialization
	void Start ()
    {
		
        // Double check there is a reference 
        if(!player_ref)
        {
            player_ref = FindObjectOfType<Player>().transform;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {

        // Follow the player only in the X axis i.e. the axis of motion
        transform.position = new Vector3(player_ref.position.x, transform.position.y, transform.position.z); 

		

	}
}
