using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	// This script will handle the acumulating the players score
	// if the player passes thru the current color
	// the score will increment by one

	public Text scoreText;

	private int score = 0;
	private int highScore = 0;
	// stored in the playerPrefs  global to all other classes
	private string highScoreKey = "_HIGHSCORE_KEY";

	void Start ()
	{
		 //Get the highScore from player prefs if it is there, 0 otherwise.
		highScore = PlayerPrefs.GetInt(highScoreKey,0);

	}

	public void ScoreIncrement ()
	{
		score++;   // increment the score by one

		PlayerPrefs.SetInt("PlayerScore", score);  // store to playerPrefs

		scoreText.text = score.ToString();  // display as a string in scene

	}


	void OnDisable()
	{
		 // When exiting the scene
		 // If our score is greter than highscore, set new higscore and save.
     if(score>highScore)
     {
			 // store to playerPrefs
       PlayerPrefs.SetInt(highScoreKey, score);
			 // save the playerprefs
       PlayerPrefs.Save();
     }
	}

}// endclass
