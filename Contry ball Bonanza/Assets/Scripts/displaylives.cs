using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class displaylives : MonoBehaviour {
	public int num_of_lives;
	Text jetext;
	// Use this for initialization
	void Awake ()
	{
		// Set up the reference.
		jetext = GetComponent <Text> ();
		num_of_lives = GameObject.FindGameObjectWithTag ("allthefunctions").GetComponent <GameControler> ().varanje;
		
		// Reset the score.
	}
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		jetext.text = "X " + num_of_lives;
	}
}
