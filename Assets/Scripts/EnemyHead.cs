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
            Debug.Log("enemy killed");
            // TODO: reset to destroy if done with debugging
            //Destroy(enemy.gameObject);
            enemy.Reset();
            // TODO: add to player score and destroy the enemy
            Debug.Log("player score prev: " + GameObject.Find("GameManager").GetComponent<GameManager>().playerScore);
            GameObject.Find("GameManager").GetComponent<GameManager>().playerScore += 100;
            Debug.Log("player score curr: " + GameObject.Find("GameManager").GetComponent<GameManager>().playerScore);
        }
    }
}
