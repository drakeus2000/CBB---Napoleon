using UnityEngine;
using System.Collections;

public class pausemenu : MonoBehaviour {
	GameObject[] pauseObjects;
	bool pauza = true;

	void Start () {
		Time.timeScale = 1;
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		hidePaused();
	}
	
	// Update is called once per frame
	void Update () {
		
		//uses the p button to pause and unpause the game
		if (Input.GetKeyDown (KeyCode.Escape))
			TogglePause ();
	}

	
	/* controls the pausing of the scene
	public void pauseControl(){
		if(Time.timeScale == 1)
		{
			Time.timeScale = 0;
			showPaused();
		} else if (Time.timeScale == 0){
			Time.timeScale = 1;
			hidePaused();
		} 
	}*/

	public void TogglePause ()
		{
			if((Time.timeScale == 1) && (pauza))
			{
				pauza = !pauza;
				Time.timeScale = 0;
				showPaused();
			} else if ((Time.timeScale == 0) && (!pauza)) {
				pauza = !pauza;
				Debug.Log ("high");
				Time.timeScale = 1;
				hidePaused();
			}
		}


	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
		}
	}
	
	//hides objects with ShowOnPause tag
	public void hidePaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}
	}
	
	//loads inputted level
	public void LoadMainMenu(){
		Application.LoadLevel("mainmenu");
	}
}