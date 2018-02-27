using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHead : MonoBehaviour {

    public Enemy enemy;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.Reset();
            // TODO: add to player score and destroy the enemy
        }
    }
}
