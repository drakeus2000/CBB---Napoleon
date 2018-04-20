using UnityEngine;
using System.Collections;

public class maincamerascript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ToggleMusic (bool checkmuzika){
		if (checkmuzika == true)
			AudioListener.pause = false;
		if (checkmuzika == false)
			AudioListener.pause = true;
	}
public void bacikameru(){
		this.transform.position = new Vector3 (-8.24f, -0.52f, -10); 
	}
public void howtobacikameru()
    {
        this.transform.position = new Vector3(-8.24f, -6.52f, -10);
    }
}