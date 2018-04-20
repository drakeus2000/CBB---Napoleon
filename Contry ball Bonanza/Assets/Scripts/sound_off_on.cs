using UnityEngine;
using System.Collections;

public class sound_off_on : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	public Sprite Musicoff;
	public Sprite MusicOn;
	private bool muzika = true;
	public maincamerascript soundoff;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("MainCamera");
		spriteRenderer = GetComponent <SpriteRenderer> ();
		soundoff = gameControllerObject.GetComponent<maincamerascript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown() {

		if (muzika)
		{
			spriteRenderer.sprite = Musicoff;
			muzika = false;
		}
		else if (!muzika)
			{
			spriteRenderer.sprite = MusicOn;
			muzika = true;
			}
		soundoff.ToggleMusic (muzika);
	}
}