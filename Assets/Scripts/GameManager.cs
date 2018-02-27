using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager: MonoBehaviour {

	Player playerComponent;
    HUD hud_ref;

	public bool gameOver = false; // is the game over?
    public int playerScore = 0;
    public int playerCoins = 0;
    public float playerTime = 300;

    void Awake()
    {

        // subscribe to scoring events 
        BasicBlock.addscore += updateTheGameScore;
        // subscribe to scoring events 
        CoinBlock.addscore += updateTheGameScore;
        // subscribe to scoring events 
        CoinBlock.addcoin += updateCoins;

    }

	// Use this for initialization
	void Start () {
		// find the player component
		playerComponent = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();

        // get a reference to the hud
        hud_ref = FindObjectOfType<HUD>();

        // update the Hud 
        updateTheGameScore(0);


    }
	
	// Update is called once per frame
	void Update () {
		// if the player number of lives is zero, game over
		if (playerComponent.Lives == 0) {
			gameOver = true;

            // pause the game
			Time.timeScale = 0.0f;
		}

        // Update the countdown time
        playerTime -= Time.deltaTime;
        hud_ref.UpdateTimer((int)playerTime);

    }

    // Listener for adding the score
    void updateTheGameScore(int increment)
    {
        playerScore += increment;
        hud_ref.UpdateScoreText(playerScore);
    }

    // Listener for adding the score
    void updateCoins()
    {
        playerCoins++;
        hud_ref.UpdateCoins(playerCoins);
    }

    


}
