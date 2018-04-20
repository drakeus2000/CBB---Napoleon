using UnityEngine;
using System.Collections;

public class splash_scene : MonoBehaviour {
    public int X;
	// Use this for initialization
	void Start () {
		StartCoroutine ("DisplayScene");
	}
	
	// Update is called once per frame
	IEnumerator DisplayScene(){
		yield return new WaitForSeconds (0.5f);
		Application.LoadLevel (X);
	}
}
