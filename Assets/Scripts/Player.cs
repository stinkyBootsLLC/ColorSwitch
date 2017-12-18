using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
// How to make a COLOR SWITCH Replica in Unity (Livestream Tutorial)

public class Player : MonoBehaviour 
{
	public float jumpForce = 10f;
	public Rigidbody2D rb;
	public string currentColor;
	public ScoreController score; // ref to script

	// this will be the Players spriterenderer
	public SpriteRenderer sr;

	// color assignment in the inspector
	// lets us access the sprite renderer component
	// the color will be random via the switch
	public Color colorCyan;
	public Color colorYellow;
	public Color colorMagenta;
	public Color colorPink;


	// Use this for initialization
	void Start () 
	{
		// added a scoring system eer - 12/18/17
		// the script has to be on this gameobject 
		// for this command to work
		score = gameObject.GetComponent<ScoreController>();
		// if script is on another game object
		//score = GameObject.Find("othergameobjectname").GetComponent<ScoreController>();

		//function call
		SetRandomColor();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//function call
		PlayerMovement ();


    }
    // seperated player movement to its own function 12/18/17 - eer
    void PlayerMovement ()
    {
		// IF button assigned to "Jump" (spacebar) 
		// OR Mouse button Down (0=left)(1=right)(2=center)
		if (Input.GetButtonDown("Jump")|| Input.GetMouseButtonDown(0))
		{
			// then jump
			rb.velocity = Vector2.up * jumpForce;
		}

    }

	void OnTriggerEnter2D (Collider2D col)
	{
		// added scoring system
		if (col.tag == currentColor)
		{
			// call a public function in different script
			score.ScoreIncrement();

		}

		
		if (col.tag == "ColorChanger")
		{
			// color changer is a different object 
			// NOT the circle
			// function call 
			// will set a new random color 
			SetRandomColor();
			// then destroy it so you can hit 
			// it again
			Destroy(col.gameObject);
			return;
		}

		// if the color tag is NOT the current color tag on the player
		if (col.tag != currentColor)
		{
			Debug.Log("GAME OVER!");

			// goes to GameOver scene
			// load scene (string)
			SceneManager.LoadScene ("GameOver");

		}

	}//end on trigger

	// need to assign a color to the player every time the player 
	// hits a color part of the circle or square
	void SetRandomColor ()
	{
		// will be seting a random color to the string currentColor

		// will be a random index for the switch case
		int index = Random.Range(0,4);

		switch (index)
		{
			case 0:
				currentColor = "Cyan";  // assigning to string
				sr.color = colorCyan;   // assigning variable sr to the color 
			break;					    //from the sprite renderer component
			case 1:
				currentColor = "Yellow";
				sr.color = colorYellow;
				break;
			case 2:
				currentColor = "Magenta";
				sr.color = colorMagenta;
				break;
			case 3:
				currentColor = "Pink";
				sr.color = colorPink;
				break;
			default:
				// what is my default?
				break;

		}

	}//end randomcolor

	
}//endclass
