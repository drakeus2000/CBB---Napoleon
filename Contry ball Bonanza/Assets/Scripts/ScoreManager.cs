using UnityEngine;
using UnityEngine.UI; // This is the call for the new UI, this MUST be in here for this to work.
using System.Collections;

public class ScoreManager : MonoBehaviour
{
	int myscore;        // The player's score.
	GameObject allthefunctions;
	
	
	Text jetext;                      // Reference to the Text component.

	void Awake ()
	{
		// Set up the reference.
		allthefunctions = GameObject.FindGameObjectWithTag ("allthefunctions");
		jetext = GetComponent <Text> ();
		
		// Reset the score.
		myscore = 0;
	}
	
	void Update ()
	{
		myscore = allthefunctions.GetComponent <GameControler> ().myscore;
		// Set the displayed text to be the word "Score" followed by the score value.
		jetext.text = "Score: " + myscore.ToString();
	}
}