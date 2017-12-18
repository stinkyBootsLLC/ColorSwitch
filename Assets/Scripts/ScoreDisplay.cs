using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// where ever you want to display scores

public class ScoreDisplay : MonoBehaviour 
{
	// Stinky Boots 2017
	// get scores from playerPrefs
	// display score in game over scene
	// eer 30-04-2017  

	public Text currentGameScore;
	public Text HighScore;

	private int currentScore;
	private int highScore;

	void Start () 
	{
		// get the current game score
		currentScore = PlayerPrefs.GetInt("PlayerScore");

		// display the current game score and convert to string
		currentGameScore.text = currentScore.ToString();

		// get the all time high score
		highScore = PlayerPrefs.GetInt("_HIGHSCORE_KEY");

		// display the all time high score and convert to string
		HighScore.text = highScore.ToString();;
	}

}
