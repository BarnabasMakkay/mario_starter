using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : Block
{

    // Event for adding score
    public delegate void AddScore(int score);
    public static event AddScore addscore;
    public delegate void AddCoin();
    public static event AddCoin addcoin;

    Transform[] cubes;

    public int scoreForDestroying = 100;
    public int numberOfCoins = 3;
    public float moveHeight = 0.3f;

    public GameObject Coin;

    private bool active = false;

    // Use this for initialization
    void Awake ()
    {
        
        // Get access to all the components
        cubes = GetComponentsInChildren<Transform>();

	}

    public override void PlayerReaction()
    {


        // destroy the block
        if (numberOfCoins == 0)
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
            if(!active)
                StartCoroutine("Animate");
        }

    }

    // Wait and then destry the block
    IEnumerator Animate()
    {


        // flag the state
        active = true;

        // get a start 
        Vector3 start = transform.position;

        // amimate the step
        for (int step = 0; step < 15; step++)
        {

            transform.position = new Vector3(start.x, start.y + moveHeight * Mathf.Sin((step / 15.0f) * Mathf.PI), start.y);
            yield return new WaitForEndOfFrame();
        }

        transform.position = start;

        // add the coin
        if (addcoin != null)
            addcoin();

        // flag the state
        active = false;

        // decrement the coins
        numberOfCoins--;

        // Spawn a coin
        var coin = Instantiate(Coin);
        coin.transform.position = transform.position + new Vector3(0.0f, 1.0f, 0.0f);

    }


}
