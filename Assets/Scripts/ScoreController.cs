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
	private string highScoreKey = "_HIGHSCORE_KEY";       // stored in the playerPrefs  global to all other classes

	void Start () 
	{
		
		highScore = PlayerPrefs.GetInt(highScoreKey,0);    //Get the highScore from player prefs if it is there, 0 otherwise.

	}

	public void ScoreIncrement ()
	{
		score++;   // increment the score by one

		PlayerPrefs.SetInt("PlayerScore", score);  // store to playerPrefs
			 
		scoreText.text = score.ToString();  // display as a string in scene

	}


	void OnDisable()
	{
		 //If our score is greter than highscore, set new higscore and save.
         if(score>highScore)
         {
             PlayerPrefs.SetInt(highScoreKey, score);  //store to playerPrefs

             PlayerPrefs.Save();   // save the playerprefs
         }
	}

}// endclass
