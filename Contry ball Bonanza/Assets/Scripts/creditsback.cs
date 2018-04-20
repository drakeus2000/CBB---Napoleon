using UnityEngine;
using System.Collections;

public class creditsback : MonoBehaviour {


	public Sprite credits2;
	Sprite credits1;
	bool klik = false;
	// Use this for initialization
	void Start () {
		credits1 = this.GetComponent<SpriteRenderer> ().sprite;
	}
	
	// Update is called once per frame
	void OnMouseDown () {
		if (!klik){
			klik = true;
			this.GetComponent<SpriteRenderer>().sprite = credits2;}
		else {
			klik = false;
            this.GetComponent<SpriteRenderer>().sprite = credits1;
            returncamera();

        }
	}
    public void returncamera()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(0.34f, -0.51f, -10);
        GameObject.Find("Button_functions").GetComponent<play>().showmainscreen();
    }
}
