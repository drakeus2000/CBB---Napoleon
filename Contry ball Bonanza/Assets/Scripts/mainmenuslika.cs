using UnityEngine;
using System.Collections;

public class mainmenuslika : MonoBehaviour {


	int randombroj;
	public Sprite[] sve_pozadine;
	// Use this for initialization
	void Start () {
		randombroj = Random.Range(0,6);
		this.GetComponent<SpriteRenderer> ().sprite = sve_pozadine [randombroj];
	}
	
	// Update is called once per frame
	public void Promenime (int broj) {
		this.GetComponent<SpriteRenderer> ().sprite = sve_pozadine [broj];
	}
}
