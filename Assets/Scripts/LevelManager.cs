using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
/*Stinky Boots LLC 2017*/
// This script will control the navigation
// thru out the game scenes
// it will also handle button events

public class LevelManager : MonoBehaviour
{

	[Tooltip("How Many Seconds till autoload next scene in build settings")]
	public float autoLoadNextLevelAfter;

	private bool effectDelay;
	private string button0Name;

	void Start()
	{
		if (autoLoadNextLevelAfter <= 0)

		{
			Debug.Log ("Auto Load Next Scene is Disabled use positive numbers\n to represent how many seconds to wait (LevelManager)");
		}
		else
		{
			// > than 0 , Must be a positive number
			// Invoke - AutoLoadScene() function, AFTER autoLoadNextLevelAfter public variable
			Invoke ("AutoLoadScene", autoLoadNextLevelAfter);
		}

		effectDelay = true; // needed for small delay on button onClick
	}


	public void LoadSceneName(string name)
	{
		// INPUT: name of the game scene
		//        pass thru inspector

		SceneManager.LoadScene (name);
	}

	public void QuitRequest()
	{
		// quit the application
		// will only work on device
		Debug.Log ("Quit requested");
		Application.Quit ();

	}

	public void AutoLoadScene()
	{

		// get active scene in build index then add 1
		// auto load the next scene in build index
		// 0 will deactivate
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);

	}


	public void LoadSceneDelayed(string name0)
	{
		// use this method to wait for a sound to play on a button
		button0Name = name0;

		if (effectDelay == true)
		{
			StartCoroutine(WaitForMusic0());
		}
		else
		{
			SceneManager.LoadScene (name0);
			Debug.Log ("New Level load: " + name0);
		}

	}

	/*******************D E L A Y S ********************/

	IEnumerator WaitForMusic0()
	{
		effectDelay = false;
		// .5 sec delay to wait for buttun audio source
		yield return new WaitForSeconds (0.5f);
		LoadSceneDelayed (button0Name);

	}
	/*******************D E L A Y S ********************/

}//end
