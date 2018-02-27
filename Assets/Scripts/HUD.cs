using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{

	// the following variables need connected up in the editor inspector
	public Text Score; // Text to display the score
    public Text Timer; // Text to display the timer
    public Text Coins; // Text to display the timer

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {


	}

    public void UpdateScoreText(int score)
    {

        // update the display for the player's number of lives
        Score.text = "MARIO\n" + score.ToString("D6");

    }

    public void UpdateTimer(int time)
    {

        // update the display for the player's number of lives
        Timer.text = "TIME\n" + time.ToString("D3");

    }


    public void UpdateCoins(int playerCoins)
    {

        // update the display for the player's number of lives
        Coins.text = "\n   x" + playerCoins.ToString("D3");

    }

}
